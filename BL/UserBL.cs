using DL;
using DTO;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class UserBL : IUserBL
    {
        IUserDL _UserDL;
        IPersonDL _PersonDL;
        //ctor
        public UserBL(IUserDL UserDL, IPersonDL PersonDL)
        {
            _UserDL = UserDL;
            _PersonDL = PersonDL;

        }
        //get{username},{password}
        public async Task<User> GetUser(string username, string password)
        {
            return await _UserDL.GetUser(username, password);
        }
        //get{id}
        public async Task<User> GetUserById(int id)
        {
            return await _UserDL.GetUserbyId(id);
        }
        //getAll
        public async Task<List<User>> GetallUser()
        {  
            return await _UserDL.GetallUser();
        }
        //post
        public async Task<int> post( string username)
        {
            string newPassword= randomPasswordGeneration(8);
            Person newperson = new Person
            {
                Identity = null,
                FirstName = null,
                LastName = null,
                Phone = null,
                Email = null,
                Country = null,
                City = null,
                Street = null,
                HouseNumber = 0,
                ApartmentNumber = 0
            };
           int personId= await _PersonDL.post(newperson);
            User u = new User { UserName = username, Password = newPassword, PersonId = personId , IsManager =false};
            sentMessege(username, newPassword);
            return await _UserDL.post(u);
   
        }

        //put
        public async Task<Person> updatePerson(Person userToChange)
        {
            return await _PersonDL.updatePerson(userToChange);

        }
        //delete
        public async Task DeleteUser(int id)
        {
            var UserToDelete = await _UserDL.GetUserbyId(id);  
            await _UserDL.DeleteUser(id);
            await _PersonDL.DeletePerson(UserToDelete.PersonId);

        }
        public void sentMessege(string email, string password)
        {
            
                
                MailAddress to = new MailAddress(email);
                MailAddress from = new MailAddress("212375158@mby.co.il");
                MailMessage message = new MailMessage(from, to);
                message.Subject = "הצטרפת בהצלחה";
               
                message.Body = "סיסמתך היא "+password+"היכנס ועדכן את שאר הפרטים בהצלחה!!!";
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                SmtpServer.Port = 587;
                SmtpServer.UseDefaultCredentials = false;
                SmtpServer.Credentials = new System.Net.NetworkCredential("212375158@mby.co.il", "CT");
                SmtpServer.EnableSsl = true;

                // code in brackets above needed if authentication required   

                try
                {
                    SmtpServer.Send(message);
                }
                catch (SmtpException ex)
                {
                    Console.WriteLine(ex);
                    //return false;
                }
                //return  password;
            
        }
        public string randomPasswordGeneration(int N)
        {
            // Initialize counter
            int i = 0;

            int randomizer = 0;

            // Seed the random-number generator
            // with current time so that the
            // numbers will be different every time
            //TimeSpan((unsigned int)(time(NULL)));

            // Array of numbers
            string numbers = "0123456789";

            // Array of small alphabets
            string letter = "abcdefghijklmnoqprstuvwyzx";

            // Array of capital alphabets
            string LETTER= "ABCDEFGHIJKLMNOQPRSTUYWVZX";

            // Array of all the special symbols
            string symbols = "!@#$^&*?";

            // Stores the random password
            string password="";
            char c;

            // To select the randomizer
            // inside the loop
            Random random = new Random();
         
            

            // Iterate over the range [0, N]
            for (i = 0; i < N; i++)
            {

                if (randomizer == 1)
                {
                    c= numbers[random.Next(0, 10)];
                    password += c;

                    //password[i] = numbers[random.Next(0, 10)];
                    randomizer = random.Next(0, 4);
                    //printf("%c", password[i]);
                }
                else if (randomizer == 2)
                {
                    c = symbols[random.Next(0, 8)];
                    password += c;

                    //password[i] = symbols[random.Next(0, 8)];
                    randomizer = random.Next(0, 4);
                    //printf("%c", password[i]);
                }
                else if (randomizer == 3)
                {
                    c = LETTER[random.Next(0, 26)];
                    password += c;
                    //password[i] = LETTER[random.Next(0, 26)];
                    randomizer = random.Next(0, 4);
                    //printf("%c", password[i]);
                }
                else
                {
                    c = letter[random.Next(0, 26)];
                    password += c;
                    //password[i] = letter[random.Next(0, 26)];
                    randomizer = random.Next(0, 4);
                    //printf("%c", password[i]);
                }
            }
            return password;
        }



    }
}
