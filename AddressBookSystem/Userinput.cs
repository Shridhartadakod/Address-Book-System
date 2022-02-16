using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AddressBookSystem
{
    internal class Userinput
    {
        
        public static string ReadString()
        {
            string input = Console.ReadLine();
            if (String.IsNullOrEmpty(input))
                return "";
            return input;
        }

        
        public static string GetName(string message)
        {
            string input;
            do
            {
                Console.Write(message);
                input = ReadString();
            } while (input == null);
            return input;
        }

        public static string GetNumber(string message)
        {
            string input;
            do
            {
                Console.Write(message);
                input = ReadString();
            } while (PhoneCheck(input) is false && input != "");
            return input;
        }

       
        public static string GetZip(string message)
        {
            string input;
            do
            {
                Console.Write(message);
                input = ReadString();
            } while (ZipCheck(input) is false);
            return input;
        }

        
        public static int GetPositiveInt(string message)
        {
            int n;
            string input;
            bool IS_INT32;
            do
            {
                do
                {
                    Console.Write(message);
                    input = ReadString();
                    IS_INT32 = Int32.TryParse(input, out n);
                } while (IS_INT32 is false);
            } while (n < 0);
            return n;
        }

        
        public static bool PhoneCheck(string input)
        {
            string phonePattern = @"(^[0-9]{10}$)|(^\+{1}[0-9]{2}[0-9]{10}$)|(^[0-9]{3}[-]{0,1}[0-9]{8}$)";
            Regex number = new Regex(phonePattern);
            Match match = number.Match(input);
            if (match.Success)
                return true;
            return false;
        }

        
        public static bool ZipCheck(string input)
        {
            string zipPattern = @"(^[0-9]{6}$)";
            Regex number = new Regex(zipPattern);
            Match match = number.Match(input);
            if (match.Success || String.IsNullOrEmpty(input))
                return true;
            return false;
        }
    }
}
