namespace CsharpPhoneBookEF.Model.BusinessLogic
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
            if (s.Length == 5)
            {
                if (s[1] != s[2] && s[2] != s[3] && ((s.Substring(0, 2) == s.Substring(3, 2)) || (s[0] == s[1] && s[3] == s[4])))
                {
                    // ab-x-ab
                    // aa-x-bb
                    return string.Format("{0}-{1}-{2}", s.Substring(0, 2), s.Substring(2, 1), s.Substring(3, 2));
                }
                else if (s[3] != s[4] && ((s.Substring(0, 2) == s.Substring(2, 2)) || (s[0] == s[1] && s[2] == s[3])))
                {
                    // ab-ab-x
                    // aa-bb-x
                    return string.Format("{0}-{1}-{2}", s.Substring(0, 2), s.Substring(2, 2), s.Substring(3));
                }
                else if (s[0] != s[1] && ((s.Substring(1, 2) == s.Substring(3, 2)) || (s[1] == s[2] && s[3] == s[4])))
                {
                    // x-ab-ab
                    // x-aa-bb
                    return string.Format("{0}-{1}-{2}", s.Substring(0, 1), s.Substring(1, 2), s.Substring(3, 2));
                }
                else if (s[1] != s[2] && s[2] == s[3] && s[3] == s[4])
                {
                    // xx-aaa
                    return string.Format("{0}-{1}", s.Substring(0, 2), s.Substring(3));
                }

                // xxx-xx
                return string.Format("{0}-{1}", s.Substring(0, 3), s.Substring(3));
            }
            if (s.Length == 6)
            {
                if ((s[2] != s[3] && ((s[0] == s[1] && s[1] == s[2]) || (s[3] == s[4] && s[4] == s[5])))    // aaa-xxx  // xxx-aaa
                    || (s.Substring(0, 3) == s.Substring(3, 3)))                                            // abc-abc
                {
                    return string.Format("{0}-{1}", s.Substring(0, 3), s.Substring(3));
                }
                else if ((s[0] == s[1] && s[2] == s[3])                 // aa-bb-xx
                        || (s[0] == s[1] && s[4] == s[5])               // aa-xx-bb
                        || (s[2] == s[3] && s[4] == s[5])               // xx-aa-bb
                        || (s.Substring(0, 2) == s.Substring(2, 2))     // ab-ab-xx
                        || (s.Substring(0, 2) == s.Substring(4, 2))     // ab-xx-ab
                        || (s.Substring(2, 2) == s.Substring(4, 2))     // xx-ab-ab
                        || s[2] == s[3])                                // xx-aa-xx
                {
                    return string.Format("{0}-{1}-{2}", s.Substring(0, 2), s.Substring(2, 2), s.Substring(4, 2));
                }

                // xxx-xxx
                return string.Format("{0}-{1}", s.Substring(0, 3), s.Substring(3));
            }
            else if (s.Length == 7)
            {
                if ((s[0] == s[1] && s[1] == s[2] && s[2] == s[3] && s[3] == s[4] && s[4] == s[5] && s[5] == s[6])
                    || (s[0] == s[1] && s[1] == s[2] && s[2] == s[3] && s[3] == s[4] && s[4] != s[5]))
                {
                    // aaa-aa-aa
                    // aaa-aa-xx
                    return string.Format("{0}-{1}-{2}", s.Substring(0, 3), s.Substring(3, 2), s.Substring(5, 2));
                }
                else if (s[1] != s[2] && s[2] == s[3] && s[3] == s[4] && s[4] == s[5] && s[5] == s[6])
                {
                    // xx-aaa-aa
                    return string.Format("{0}-{1}-{2}", s.Substring(0, 2), s.Substring(2, 3), s.Substring(5, 2));
                }
                else if (s[2] != s[3] && s[3] != s[4]
                    && ((s[0] == s[1] && s[1] == s[2] && s[4] == s[5] && s[5] == s[6]) || s.Substring(0, 3) == s.Substring(4, 3)))
                {
                    // aaa-x-bbb
                    // abc-x-abc
                    return string.Format("{0}-{1}-{2}", s.Substring(0, 3), s.Substring(3, 1), s.Substring(4, 3));
                }
                else if (s[5] != s[6]
                    && ((s[0] == s[1] && s[1] == s[2] && s[3] == s[4] && s[4] == s[5]) || s.Substring(0, 3) == s.Substring(3, 3)))
                {
                    // aaa-bbb-x
                    // abc-abc-x
                    return string.Format("{0}-{1}-{2}", s.Substring(0, 3), s.Substring(3, 3), s.Substring(6, 1));
                }
                else if (s[0] != s[1]
                    && ((s[1] == s[2] && s[2] == s[3] && s[4] == s[5] && s[5] == s[6]) || s.Substring(1, 3) == s.Substring(4, 3)))
                {
                    // x-aaa-bbb
                    // x-abc-abc
                    return string.Format("{0}-{1}-{2}", s.Substring(0, 1), s.Substring(1, 3), s.Substring(4, 3));
                }
                else if (s[0] == s[1] && s[1] == s[2] && s[2] != s[3])
                {
                    // aaa-xx-xx
                    return string.Format("{0}-{1}-{2}", s.Substring(0, 3), s.Substring(3, 2), s.Substring(5, 2));
                }
                else if (s[2] == s[3] && s[3] == s[4] && s[4] != s[5] && s[1] != s[2])
                {
                    // xx-aaa-xx
                    return string.Format("{0}-{1}-{2}", s.Substring(0, 2), s.Substring(2, 3), s.Substring(5, 2));
                }
                else if (s[3] != s[4] && s[4] == s[5] && s[5] == s[6])
                {
                    // xx-xx-aaa
                    return string.Format("{0}-{1}-{2}", s.Substring(0, 2), s.Substring(2, 2), s.Substring(4, 3));
                }
                else if ((s[3] == s[4] && s[5] == s[6]) || s.Substring(3, 2) == s.Substring(5, 2))
                {
                    // xxx-aa-bb
                    // xxx-ab-ab
                    return string.Format("{0}-{1}-{2}", s.Substring(0, 3), s.Substring(3, 2), s.Substring(5, 2));
                }
                else if ((s[0] == s[1] && s[5] == s[6]) || s.Substring(0, 2) == s.Substring(5, 2))
                {
                    // aa-xxx-bb
                    // ab-xxx-ab
                    return string.Format("{0}-{1}-{2}", s.Substring(0, 2), s.Substring(2, 3), s.Substring(5, 2));
                }
                else if ((s[0] == s[1] && s[2] == s[3]) || s.Substring(0, 2) == s.Substring(2, 2))
                {
                    // aa-bb-xxx
                    // ab-ab-xxx
                    return string.Format("{0}-{1}-{2}", s.Substring(0, 2), s.Substring(2, 2), s.Substring(4, 3));
                }

                // xxx-xx-xx
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