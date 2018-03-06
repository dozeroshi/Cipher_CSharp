using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace CipherProgram
{
    /// <summary>
    /// Runs the cipher program
    /// </summary>
    class CipherProgram
    {
        /// <summary>
        /// The main class
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            CaesarCipher cipher = new CaesarCipher(3);

            //Get the message we want to encrypt/decrypt
            Console.WriteLine("Type your message");
            string userString = Console.ReadLine();
            userString = Regex.Replace(userString, @"\s+", "");

            Console.WriteLine("\n");

            string[] menuOptions = { "1", "2", "3", "4" };
            bool showMenu = true;

            //show the menu options
            while (showMenu)
            {
                Console.WriteLine("Action:\n");
                Console.WriteLine("1 - Encrypt Message");
                Console.WriteLine("2 - Decrypt Message");
                Console.WriteLine("3 - Change Message");
                Console.WriteLine("4 - Exit Program");

                string userSelection = Console.ReadLine();

                //if we didnt get a valid menu selection, try again
                if (menuOptions.Contains(userSelection) == false)
                {
                    Console.WriteLine("\nPlease select a valid option\n");
                }
                else
                {
                    //work out what we want to do
                    switch (userSelection)
                    {
                        //encrypt the current message
                        case "1":
                            Console.WriteLine("{0}{1}", "Result: ", cipher.Encrypt(userString));
                            break;

                        //decrypt the current message
                        case "2":
                            Console.WriteLine("{0}{1}", "Result: ", cipher.Decrypt(userString));
                            break;

                        //change the current message
                        case "3":
                            Console.WriteLine("Type your message");
                            userString = Console.ReadLine();
                            userString = Regex.Replace(userString, @"\s+", "");
                            break;

                        //exit the program
                        case "4":
                            showMenu = false;
                            break;
                    }//end switch
                }//end if

            }//end while

        }//end Main()

    }//end CipherProgram

    /// <summary>
    /// Handles the encryption/decryption operations
    /// </summary>
    class CaesarCipher
    {
        //the key we are shifting by
        private int shiftKey;

        //class constructor
        public CaesarCipher(int key)
        {
            this.shiftKey = key;
        }//end constructor

        /// <summary>
        /// Encrypt the plaintext string and return the ciphertext
        /// </summary>
        /// <param name="plaintext"></param>
        /// <returns>ciphertext</returns>
        public string Encrypt(string plaintext)
        {
            string ciphertext = "";

            foreach (char ch in plaintext)
            {
                ciphertext += ShiftChar(ch);
            }

            return ciphertext;
        }//end Encrypt()

        /// <summary>
        /// Decrypt the plaintext string and return the ciphertext
        /// </summary>
        /// <param name="plaintext"></param>
        /// <returns>ciphertext</returns>
        public string Decrypt(string plaintext)
        {
            string ciphertext = "";

            //reverse the shiftKey
            this.shiftKey = -shiftKey;

            foreach (char ch in plaintext)
            {
                ciphertext += ShiftChar(ch);
            }

            //reverse the shiftKey back again
            this.shiftKey = -shiftKey;

            return ciphertext;
        }//end Encrypt()

        /// <summary>
        /// This method does the shift on the passed char
        /// </summary>
        /// <param name="ch"></param>
        /// <returns>ch</returns>
        public char ShiftChar(char ch)
        {
            ch = (char)(ch + this.shiftKey);

            //handle alphabet wrap
            if (ch > 'z')
            {
                return (char)(ch - 26);
            }
            else if (ch < 'a')
            {
                return (char)(ch + 26);
            }

            return ch;
        }//end ShiftChar()

    }//CaesarCipher
}

