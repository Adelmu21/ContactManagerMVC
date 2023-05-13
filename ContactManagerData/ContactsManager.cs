using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ContactsData
{
    /// <summary>
    /// methods for working with Movie table in Movies database
    /// </summary>
    public static class ContactsManager
    {

        /// <summary>
        /// retrieve  all movies
        /// </summary>
        /// <param name="db">context object</param>
        /// <returns>list of movies or null if none</returns>
        public static List<Contact> GetContacts(ContactsContext db) // dependency injection
        {
            List<Contact> contacts = null;
            
            //using (ContactsContext db = new ContactsContext())
            //{
                contacts = db.Contacts.Include(c => c.Category).ToList();
            //}
            return contacts;
        }

        /// <summary>
        /// retrieve movie genres
        /// </summary>
        /// <param name="db">context object</param>
        /// <returns>list of genres</returns>
        public static List<Category> GetCategories(ContactsContext db)
        {
            List<Category> categories = db.Categories.OrderBy(r => r.Name).ToList();
            return categories;
        }

        /// <summary>
        /// get movie with given ID
        /// </summary>
        /// <param name="db">context object</param>
        /// <param name="id">ID of the  movie to find</param>
        /// <returns>movie or null if not found</returns>
        public static Contact GetContactById(ContactsContext db, int id)
        {
            Contact contact = db.Contacts.Find(id);
            return contact;
        }


        /// <summary>
        /// add another movie to the table
        /// </summary>
        /// <param name="db">context object</param>
        /// <param name="movie">new movie to add</param>
        public static void AddContact(ContactsContext db, Contact contact)
        {
            if (contact != null)
            {
                db.Contacts.Add(contact);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// update movie with given id using new movie data
        /// </summary>
        /// <param name="db">context object</param>
        /// <param name="id">id for the movie to update</param>
        /// <param name="newMovie">new movie data</param>
        public static void UpdateContact(ContactsContext db, int id, Contact newContact)
        {
            Contact contact = db.Contacts.Find(id);
            if (contact != null)
            {
                // copy over new movie data
                contact.FirstName = newContact.FirstName;
                contact.LastName = newContact.LastName;
                contact.Phone = newContact.Phone;
                contact.Email = newContact.Email;
                contact.CategoryId = newContact.CategoryId;
                db.SaveChanges();
            }
        }

        /// <summary>
        /// delete movie with given id
        /// </summary>
        /// <param name="db">context object</param>
        /// <param name="id">ID of the movie to delete</param>
        public static void DeleteContact(ContactsContext db, int id)
        {
            Contact contact = db.Contacts.Find(id);
            if (contact != null)
            {
                db.Contacts.Remove(contact);
                db.SaveChanges();
            }
        }
    }
}
