namespace ProPWAShop.Data
{
    public class ModelConstants
    {
        public class Common
        {
            public const int MinNameLength = 3;
            public const int MaxNameLength = 50;
        }

        public class Identity
        {
            public const int MinEmailLength = 3;
            public const int MaxEmailLength = 50;
            public const int MinPasswordLength = 6;
        }

        public class Address
        {
            public const int MaxCommentLength = 255;
            public const int MaxDescriptionLength = 1000;
            public const int MinPhoneNumberLength = 7;
            public const int MaxPhoneNumberLength = 13;
            public const string PhoneNumberRegularExpression = @"\+[0-9]*";
        }

        public class Product
        {
            public const int MinQuantity = 1;
            public const int MaxQuantity = int.MaxValue;
            public const int MaxUrlLength = 2048;
            public const int MaxDescriptionLength = 1000;
            public const string MinPrice = "1";
            public const string MaxPrice = "100000";
        }
    }
}