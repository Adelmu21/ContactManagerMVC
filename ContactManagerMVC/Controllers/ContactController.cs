using System.Diagnostics;
using ContactManagerMVC.Models;
using Microsoft.AspNetCore.Mvc;
using ContactsData;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ContactManagerMVC.Controllers
{
    public class ContactController : Controller
    {
        private ContactsContext _context { get; set; }

        public ContactController(ContactsContext context)
        {
            _context = context;
        }

        public ActionResult Index()
        {
            List<Contact> contacts = ContactsManager.GetContacts(_context);
            var list = new SelectList(contacts, "CategoryId", "Name");
            ViewBag.categories = list;
            return View(contacts);
        }
        // GET: Contact Controller for showing existing contact data
        public ActionResult Details(int id)
        {
            Contact contact = ContactsManager.GetContactById(_context, id);
            return View(contact);
        }
        // GET: Contact Controller for adding new contact data
        public ActionResult Create()
        {
            List<Category> categories = ContactsManager.GetCategories(_context);
            var list = new SelectList(categories, "CategoryId", "Name");
            ViewBag.categories = list;
            Contact contact = new Contact(); // empty contact object
            return View(contact);
        }
        // POST: Contact Controller for adding new contact data
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Contact newContact)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    ContactsManager.AddContact(_context, newContact);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View(newContact);
                }
            }
            catch
            {
                return View(newContact);
            }
        }
        // POST: Contact Controller for editing Contacts
        public ActionResult Edit(int id)
        {
            List<Category> categories = ContactsManager.GetCategories(_context);
            var list = new SelectList(categories, "CategoryId", "Name");
            ViewBag.Categories = list;
            Contact contact = ContactsManager.GetContactById(_context, id);
            return View(contact);
        }

        // POST: Contact Controller for editing Contacts
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Contact newContact)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ContactsManager.UpdateContact(_context, id, newContact);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View(newContact);
                }
            }
            catch
            {
                return View(newContact);
            }
        }

        // GET: Contact Controller for Deleting data
        public ActionResult Delete(int id)
        {
            Contact contact = ContactsManager.GetContactById(_context, id);
            return View(contact);
        }

        // POST: Contact Controller for Deleting data
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Contact contact)
        {
            try
            {
                ContactsManager.DeleteContact(_context, id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}