using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public void bookSession(Session session)
        {
            _context.Sessions.Add(session);
            _context.SaveChanges();
        }

        public void makePaymentIndividual(IndividualBooking individualBooking)
        {
            individualBooking.Paid = true;
            _context.SaveChanges();
        }

        public void makePaymentGroup(GroupBooking groupBooking)
        {
            groupBooking.Paid = true;
            _context.SaveChanges();
        }

        public void addTutor(Tutor tutor)
        {
            _context.Tutors.Add(tutor);
            _context.SaveChanges();
        }


    }

}
