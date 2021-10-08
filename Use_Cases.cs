﻿using System;
using System.Collections.Generic;
using System.Linq;
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

        public void bookSessionGroup(GroupBooking booking)
        {
            _context.GroupBookings.Add(booking);
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

        public void rateTutor()
        {

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
