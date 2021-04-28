using HotelBookingBot.Models;

namespace HotelBookingBot
{
	public static class EnumExtensions
	{
		public static HotelStarsType ToStars(this string stars)
		{
			switch (stars)
			{
				case "*": return HotelStarsType.One;
				case "**": return HotelStarsType.Two;
				case "***": return HotelStarsType.Three;
				case "****": return HotelStarsType.Four;
				case "*****": return HotelStarsType.Five;
			}

			return HotelStarsType.Five;
		}

		public static string ToStarsString(this HotelStarsType stars)
		{
			switch (stars)
			{
				case HotelStarsType.One: return "*";
				case HotelStarsType.Two: return "**";
				case HotelStarsType.Three: return "***";
				case HotelStarsType.Four: return "****";
				case HotelStarsType.Five: return "*****";
			}

			return "*****";
		}

		public static RoomType ToRoom(this string roomType)
		{
			switch (roomType)
			{
				case "sngl": return RoomType.Sngl;
				case "dbl": return RoomType.Dbl;
				case "twin": return RoomType.Twin;
				case "trpl": return RoomType.Trpl;
				case "qdpl": return RoomType.Qdpl;
				case "exb": return RoomType.Exb;
			}

			return RoomType.Sngl;
		}

		public static string ToEnumString(this RoomType roomType)
		{
			switch (roomType)
			{
				case RoomType.Sngl: return "Одиночный(sngl)";
				case RoomType.Dbl: return "Двойной(dbl)";
				case RoomType.Twin: return "Двойной раздельный(twin)";
				case RoomType.Trpl: return "Тройной(trpl)";
				case RoomType.Qdpl: return "Четверной(qdpl)";
				case RoomType.Exb: return "Двойной с кроватью(exb)";
			}

			return "Одиночный(sngl)";
		}

		public static (int, int) PriceExpression(this string filter)
		{
			var result = (0, 1000000);

			if (filter.Contains("-"))
			{
				var filters = filter.Split('-');
				return (int.Parse(filters[0]), int.Parse(filters[1]));
			}

			return result;
		}
	}
}