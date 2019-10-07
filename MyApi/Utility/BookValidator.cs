using MyApi.Data;
using MyApi.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApi.Utility
{
    public class BookValidator
    {
        private bool ValidateId(int id)
        {
            if (id > 0)
            {
                return true;
            }
            else
            {
                throw new InvalidIdException();
            }
        }

        private bool ValidatePrice(double price)
        {
            if (price > 0)
            {
                return true;
            }
            else
            {
                throw new InvalidPriceException();
            }
        }

        private bool ValidateName(string name)
        {
            if (!(name.ToCharArray().Any(char.IsDigit)))
            {
                return true;
            }
            else
            {
                throw new InvalidNameExcption();
            }
        }

        private bool ValidateAuthor(string author)
        {
            if (!(author.ToCharArray().Any(char.IsDigit)))
            {
                return true;
            }
            else
            {
                throw new InvalidAuthorNameException();
            }
        }

        private bool ValidateCategory(string category)
        {
            if (!(category.ToCharArray().Any(char.IsDigit)))
            {
                return true;
            }
            else
            {
                throw new InvalidCategoryException();
            }
        }


        public List<String> Validate( Book book)
        {
            List<String> exceptions = new List<string>();
            try { ValidateId(book.Id); }
            catch (Exception ex) { exceptions.Add(ex.GetType().Name); }

            try { ValidateName(book.Name); }
            catch (Exception ex) { exceptions.Add(ex.GetType().Name); }

            try { ValidateAuthor(book.Author); }
            catch (Exception ex) { exceptions.Add(ex.GetType().Name); }

            try { ValidatePrice(book.Price); }
            catch (Exception ex) { exceptions.Add(ex.GetType().Name); }

            try { ValidateCategory(book.Category); }
            catch (Exception ex) { exceptions.Add(ex.GetType().Name); }

            return exceptions;
        }
    }
}