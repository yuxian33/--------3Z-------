using Server.Envir;

namespace Server.Models
{
	public static class MapObjectExtensions
	{
		public static bool HasNode(this MapObject mapObject)
		{
			if (mapObject != null && SEnvir.HasObject(mapObject.ObjectID))
			{
				return true;
			}
			return false;
		}

		public static bool HasNoNode(this MapObject mapObject)
		{
			return !mapObject.HasNode();
		}
	}
}
