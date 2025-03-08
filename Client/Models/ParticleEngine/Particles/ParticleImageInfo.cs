using Client.Envir;
using Library;
using System.Drawing;

namespace Client.Models.ParticleEngine
{
    public class ParticleImageInfo
    {
        public Size Size = Size.Empty;
        public MirLibrary Library;
        public int Index;

        public ParticleImageInfo(LibraryFile file, int index)
        {
            Index = index;
            if (!CEnvir.LibraryList.TryGetValue(file, out Library))
                return;
            Size = Library.GetSize(index);
        }
    }
}
