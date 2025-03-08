using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Library.CartoonMirDB;
using Library.SystemModels;

namespace CartoonMirDB
{
    public sealed class Session
    {
        /*
        private const string Extention = @".db";
        private const string TempExtention = @".TMP";
        private const string CompressExtention = @".gz";
        */

        private const string AES_READ_KEYPHRASE = "AbasjJAs2asSa21OZXjBjksk40poSjsP";
        private const string IV_READ = "O9p0skPAs1SaSnlP";
        private const string AES_WRITE_KEYPHRASE = "AbasjJAs2asSa21OZXjBjksk40poSjsP";
        private const string IV_WRITE = "O9p0skPAs1SaSnlP";
        public const string Extention = ".db";
        private const string TempExtention = ".TMP";
        public const string CompressExtention = ".gz";
        private byte[] AES_READ_KEY { get; set; }
        private byte[] READ_IV { get; set; }
        private byte[] AES_WRITE_KEY { get; set; }
        private byte[] WRITE_IV { get; set; }

        private string Root { get; }
        internal SessionMode Mode { get; }

        public bool BackUp { get; set; } = true;
        public int BackUpDelay { get; set; }
        private string BackupRoot { get; }

        public string SystemPath => Root + "System.db";
        public string SystemBackupPath => BackupRoot + @"System\";
        private byte[] SystemHeader;

        private string UsersPath => Root + "Users.db";
        private string UsersBackupPath => BackupRoot + @"Users\";
        private byte[] UsersHeader;

  
        internal Dictionary<Type, DBRelationship> Relationships = new Dictionary<Type, DBRelationship>();

        private Dictionary<Type, ADBCollection> Collections;

        public Session(SessionMode mode, string root = @".\Database\", string backup = @".\Backup\")
        {
            Root = root;
            BackupRoot = backup;
            Mode = mode;

            InitializeCrypto();
            Initialize();
        }
        private void InitializeCrypto()
        {
            AES_READ_KEY = Encoding.ASCII.GetBytes("wMtp4PJnz7bffqJPy9HiOKwLsVPiurxt");
            READ_IV = Encoding.ASCII.GetBytes("mqFzf1trGKkm2zl9");
            AES_WRITE_KEY = Encoding.ASCII.GetBytes("wMtp4PJnz7bffqJPy9HiOKwLsVPiurxt");
            WRITE_IV = Encoding.ASCII.GetBytes("mqFzf1trGKkm2zl9");
        }

        private void Initialize()
        {
            if (!Directory.Exists(Root))
                Directory.CreateDirectory(Root);

            Collections = new Dictionary<Type, ADBCollection>();

            List<Type> types = new List<Type>();
            types.AddRange(Assembly.GetEntryAssembly().GetTypes());
            types.AddRange(Assembly.GetExecutingAssembly().GetTypes());
            types.AddRange(Assembly.GetCallingAssembly().GetTypes());

            Type collectionType = typeof(DBCollection<>);

            foreach (Type type in types)
            {
                if (!type.IsSubclassOf(typeof(DBObject))) continue;

                Collections[type] = (ADBCollection)Activator.CreateInstance(collectionType.MakeGenericType(type), this);
            }

            InitializeSystem();

            if ((Mode & SessionMode.Users) == SessionMode.Users)
                InitializeUsers();

            Parallel.ForEach(Relationships, x => x.Value.ConsumeKeys(this));

            Relationships = null;
            /*
            DBCollection<ItemInfo> itemList = GetCollection<ItemInfo>();

            ItemInfo Female = (ItemInfo)itemList.GetObjectByIndex(1100);
            ItemInfo Male = (ItemInfo)itemList.GetObjectByIndex(1043);

            int maleIndex = itemList.Binding.IndexOf(Male );
            Female.Index = 1044;
            itemList.Binding.Remove(Female);
            itemList.Binding.Insert(maleIndex  + 1, Female);
               */
            

            foreach (KeyValuePair<Type, ADBCollection> pair in Collections)
                pair.Value.OnLoaded();
        }
      
        
        private void InitializeSystem()
        {
            List<DBMapping> dbMappingList = new List<DBMapping>();
            if ((this.Mode & SessionMode.System) == SessionMode.System)
            {
                foreach (KeyValuePair<Type, ADBCollection> collection in this.Collections)
                {
                    if (collection.Value.IsSystemData)
                        dbMappingList.Add(collection.Value.Mapping);
                }
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (BinaryWriter writer = new BinaryWriter((Stream)memoryStream))
                    {
                        writer.Write(dbMappingList.Count);
                        foreach (DBMapping dbMapping in dbMappingList)
                            dbMapping.Save(writer);
                        this.SystemHeader = memoryStream.ToArray();
                    }
                }
                dbMappingList.Clear();
            }
            if (!File.Exists(this.SystemPath))
                return;
            using (MemoryStream memoryStream = new MemoryStream(Library.CartoonMirDB.Crypto.Crypto.AesUtils.Decrypt(File.ReadAllBytes(this.SystemPath), this.AES_READ_KEY, this.READ_IV)))
            {
                using (BinaryReader reader = new BinaryReader((Stream)memoryStream))
                {
                    int num = reader.ReadInt32();
                    for (int index = 0; index < num; ++index)
                        dbMappingList.Add(new DBMapping(reader));
                    List<Task> taskList = new List<Task>();
                    foreach (DBMapping dbMapping in dbMappingList)
                    {
                        DBMapping mapping = dbMapping;
                        byte[] data = reader.ReadBytes(reader.ReadInt32());
                        ADBCollection value;
                        if (!(mapping.Type == (Type)null) && this.Collections.TryGetValue(mapping.Type, out value))
                            taskList.Add(Task.Run((Action)(() => value.Load(data, mapping))));
                    }
                    if (taskList.Count <= 0)
                        return;
                    Task.WaitAll(taskList.ToArray());
                }
            }
        }
        
        private void InitializeUsers()
        {
            List<DBMapping> mappings = new List<DBMapping>();

            foreach (KeyValuePair<Type, ADBCollection> pair in Collections)
            {
                if (pair.Value.IsSystemData) continue;

                mappings.Add(pair.Value.Mapping);
            }

            using (MemoryStream stream = new MemoryStream())
            using (BinaryWriter writer = new BinaryWriter(stream))
            {
                writer.Write(mappings.Count);
                foreach (DBMapping mapping in mappings)
                    mapping.Save(writer);

                UsersHeader = stream.ToArray();
            }
            mappings.Clear();

            if (!File.Exists(UsersPath)) return;

            using (BinaryReader reader = new BinaryReader(File.OpenRead(UsersPath)))
            {
                int count = reader.ReadInt32();

                for (int i = 0; i < count; i++)
                    mappings.Add(new DBMapping(reader));

                List<Task> loadingTasks = new List<Task>();
                foreach (DBMapping mapping in mappings)
                {
                    byte[] data = reader.ReadBytes(reader.ReadInt32());

                    ADBCollection value;
                    if (mapping.Type == null || !Collections.TryGetValue(mapping.Type, out value)) continue;

                    loadingTasks.Add(Task.Run(() => value.Load(data, mapping)));
                }

                if (loadingTasks.Count > 0)
                    Task.WaitAll(loadingTasks.ToArray());
            }
        }

        public void Save(bool commit)
        {
            Parallel.ForEach(Collections, x => x.Value.SaveObjects());

            if (commit)
                Commit();
        }
        public void Commit()
        {
            SaveSystem();
            SaveUsers();
        }
       

        private void SaveSystem()
        {
            if ((this.Mode & SessionMode.System) != SessionMode.System)
                return;
            if (!Directory.Exists(this.Root))
                Directory.CreateDirectory(this.Root);
            using (MemoryStream memoryStream = new MemoryStream())
            {
                using (BinaryWriter binaryWriter = new BinaryWriter((Stream)memoryStream))
                {
                    binaryWriter.Write(this.SystemHeader);
                    foreach (KeyValuePair<Type, ADBCollection> collection in this.Collections)
                    {
                        if (collection.Value.IsSystemData)
                        {
                            byte[] saveData = collection.Value.GetSaveData();
                            binaryWriter.Write(saveData.Length);
                            binaryWriter.Write(saveData);
                        }
                    }
                }
                File.WriteAllBytes(this.SystemPath + ".TMP", Library.CartoonMirDB.Crypto.Crypto.AesUtils.Encrypt(memoryStream.ToArray(), this.AES_WRITE_KEY, this.WRITE_IV));
            }
            if (this.BackUp && !Directory.Exists(this.SystemBackupPath))
                Directory.CreateDirectory(this.SystemBackupPath);
            if (File.Exists(this.SystemPath))
            {
                if (this.BackUp)
                {
                    using (FileStream fileStream1 = File.OpenRead(this.SystemPath))
                    {
                        using (FileStream fileStream2 = File.Create(this.SystemBackupPath + "System " + this.ToBackUpFileName(DateTime.UtcNow) + ".db.gz"))
                        {
                            using (GZipStream gzipStream = new GZipStream((Stream)fileStream2, CompressionMode.Compress))
                                fileStream1.CopyTo((Stream)gzipStream);
                        }
                    }
                }
                File.Delete(this.SystemPath);
            }
            File.Move(this.SystemPath + ".TMP", this.SystemPath);
        }

        private void SaveUsers()
        {
            if ((Mode & SessionMode.Users) != SessionMode.Users) return;

            if (!Directory.Exists(Root))
                Directory.CreateDirectory(Root);

            using (BinaryWriter writer = new BinaryWriter(File.Create(UsersPath + TempExtention)))
            {
                writer.Write(UsersHeader);

                foreach (KeyValuePair<Type, ADBCollection> pair in Collections)
                {
                    if (pair.Value.IsSystemData) continue;

                    byte[] data = pair.Value.GetSaveData();

                    writer.Write(data.Length);
                    writer.Write(data);
                }
            }
            if (BackUp && !Directory.Exists(UsersBackupPath))
                Directory.CreateDirectory(UsersBackupPath);

            if (File.Exists(UsersPath))
            {
                if (BackUp)
                {
                    using (FileStream sourceStream = File.OpenRead(UsersPath))
                    using (FileStream destStream = File.Create(UsersBackupPath + "Users " + ToBackUpFileName(DateTime.UtcNow) + Extention + CompressExtention))
                    using (GZipStream compress = new GZipStream(destStream, CompressionMode.Compress))
                        sourceStream.CopyTo(compress);
                }

                File.Delete(UsersPath);
            }

            File.Move(UsersPath + ".TMP", UsersPath);
        }

        public DBCollection<T> GetCollection<T>() where T : DBObject, new()
        {
            return (DBCollection<T>)Collections[typeof(T)];
        }
        public ADBCollection GetCollection(Type type)
        {
            return Collections[type];
        }
        internal DBObject GetObject(Type type, int index)
        {
            return Collections[type].GetObjectByIndex(index);
        }
        public DBObject GetObject(Type type, string fieldName, object value)
        {
            return Collections[type].GetObjectbyFieldName(fieldName, value);
        }

        internal T CreateObject<T>() where T : DBObject, new()
        {
            return (T)Collections[typeof(T)].CreateObject();
        }

        private static string ToFileName(DateTime time)
        {
            return $"{time.Year:0000}-{time.Month:00}-{time.Day:00} {time.Hour:00}-{time.Minute:00}";
        }
        public string ToBackUpFileName(DateTime time)
        {
            if (BackUpDelay == 0)
                return ToFileName(time);

            time = new DateTime(time.Ticks - (time.Ticks % (BackUpDelay * TimeSpan.TicksPerMinute)));

            return $"{time.Year:0000}-{time.Month:00}-{time.Day:00} {time.Hour:00}-{time.Minute:00}";
        }
        internal void Delete(DBObject ob)
        {
            if (ob.IsDeleted) return;

            Collections[ob.ThisType].Delete(ob);

            ob.OnDeleted();

            PropertyInfo[] properties = ob.ThisType.GetProperties(BindingFlags.FlattenHierarchy | BindingFlags.Public | BindingFlags.Instance | BindingFlags.GetProperty | BindingFlags.SetProperty);

    
            foreach (PropertyInfo property in properties)
            {
                Association link = property.GetCustomAttribute<Association>();

                if (property.PropertyType.IsSubclassOf(typeof(DBObject)))
                {
                    if (link != null && link.Aggregate)
                    {
                        DBObject tempOb = (DBObject)property.GetValue(ob);

                        tempOb?.Delete();
                        continue;
                    }

                    property.SetValue(ob, null);
                    continue;
                }

                if (!property.PropertyType.IsGenericType || property.PropertyType.GetGenericTypeDefinition() != typeof(DBBindingList<>)) continue;

                IBindingList list = (IBindingList)property.GetValue(ob);

                if (link != null && link.Aggregate)
                {
                    for (int i = list.Count - 1; i >= 0; i--)
                        ((DBObject)list[i]).Delete();
                    continue;
                }

                list.Clear();
            }

        }
        internal void FastDelete(DBObject ob)
        {
            if (ob.IsDeleted) return;

            ob.IsTemporary = true;

            ob.OnDeleted();
        }
    }
}
