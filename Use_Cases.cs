using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TutorBuddy_MCsoft.Areas.Identity.Data;
using TutorBuddy_MCsoft.Data;
using TutorBuddy_MCsoft.Models;

namespace TutorBuddy_MCsoft
{
    public class Use_Cases
    {
        private readonly TutorBuddy_MCsoftContext _context;
        public Use_Cases(TutorBuddy_MCsoftContext context)
        {
            _context = context;
        }

        //approved and rating are not set by ui
       
        public void addStudent(Student student)
        {
            _context.Student.Add(student);
            _context.SaveChanges();
        }

        public void updateStudent(Student student)
        {
            _context.Student.Attach(student);
            _context.SaveChanges();
        }

        public List<Tutor> browseTutors()
        {
            return _context.Tutors.ToList();
        }

        public void bookSessionIndividual(IndividualBooking booking)
        {
            _context.IndividualBookings.Add(booking);
            _context.SaveChanges();
        }

        public void makePaymentIndividual(IndividualBooking individualBooking)
        {
            individualBooking.Paid = true;
            _context.SaveChanges();
        }

        public void addReview(Review review)
        {
            _context.Reviews.Add(review);
            _context.SaveChanges();
            Tutor cur = review.Tutor;
            IEnumerable<Review> reviews = _context.Reviews.Where(rv => rv.Tutor == cur);
            double avg = reviews.Sum(rv => rv.Rating) / (double) reviews.Count();
            cur.AvgRating = avg;
            _context.SaveChanges();
        }

        public void addTutor(Tutor tutor)
        {
            _context.Tutors.Add(tutor);
            _context.SaveChanges();
        }

        public void approveTutor(Tutor tutor)
        {
            tutor.Approved = true;
            _context.SaveChanges();
        }

        public static string greeting(TutorBuddy_MCsoftContext context, TutorBuddy_MCsoftUser user)
        {
            if (user.Role == "admin")
            {
                return "Admin";
            }
            if (user.Role == "tutor")
            {
                return context.Tutors.FirstOrDefault(t => t.StudentNumber == user.StudentNumber).UserName;
            }
            return context.Student.FirstOrDefault(t => t.StudentNumber == user.StudentNumber).UserName;
        }

        
    }

}
