namespace CsharpPhoneBookEF.BusinessLogic
{
    public class PhoneFormatting
    {
        public static string SimplifyPhone(string s)
        {
            var phone = s.Trim().Replace("-", "").Replace("(", "").Replace(")", "").Replace(" ", "");

            if (phone.Length == 11 && phone.StartsWith("8"))
            {
                return "+7" + phone.Substring(1);
            }

            return phone;
        }

        public static string FormatPhone(string s)
        {
            if (s.Length == 4)
            {
                return string.Format("{0}-{1}", s.Substring(0, 2), s.Substring(2, 2));
            }
            if (s.Length == 6 || s.Length == 5)
            {
                return string.Format("{0}-{1}", s.Substring(0, 3), s.Substring(3));
            }
            else if (s.Length == 7)
            {
                return string.Format("{0}-{1}-{2}", s.Substring(0, 3), s.Substring(3, 2), s.Substring(5, 2));
            }
            else if (s.Length == 12 && s.Substring(0, 3) == "+79")
            {
                return string.Format("{0}-{1}-{2}-{3}-{4}", s.Substring(0, 2), s.Substring(2, 3), s.Substring(5, 3), s.Substring(8, 2), s.Substring(10, 2));
            }
            else if (s.Length == 12 && s.Substring(0, 2) == "+7")
            {
                return string.Format("{0}({1}){2}-{3}-{4}", s.Substring(0, 2), s.Substring(2, 3), s.Substring(5, 3), s.Substring(8, 2), s.Substring(10, 2));
            }
            else if (s.Length == 12 && s.StartsWith("+"))
            {
                return string.Format("{0}-{1}-{2}-{3}", s.Substring(0, 3), s.Substring(3, 3), s.Substring(6, 3), s.Substring(9, 3));
            }

            return s;
        }
    }
}