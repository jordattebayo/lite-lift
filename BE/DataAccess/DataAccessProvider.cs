using BE.Models;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace BE.DataAccess
{
    public class DataAccessProvider : IDataAccessProvider
    {
        private readonly PostgreSqlContext _context;

        public DataAccessProvider(PostgreSqlContext context)
        {
            _context = context;
        }

        // public Guid AddWorkout(Workout workout)
        // {
        //     _context.Workouts.Add(workout);
        //     _context.SaveChanges();
        //     Guid sid = workout.Sid;
        //     return sid;
        // }
        //
        // public void UpdateWorkout(Guid sid, Workout updatedWorkout)
        // {
        //     var workout = _context.Workouts.FirstOrDefault<Workout>(w => w.Sid == sid);
        //     if (workout == null) return;
        //     workout.Notes = updatedWorkout.Notes;
        //     workout.Date = updatedWorkout.Date;
        //     _context.SaveChanges();
        // }
        //
        // public void DeleteWorkout(Guid sid)
        // {
        //     var workout = _context.Workouts.FirstOrDefault(w => w.Sid == sid);
        //     if (workout != null)
        //     {
        //         _context.Workouts.Remove(workout);
        //         _context.SaveChanges();
        //     }
        // }
        //
        // public Workout? GetWorkoutById(Guid sid)
        // {
        //     var workout = _context.Workouts.FirstOrDefault(w => w.Sid == sid);
        //     return workout;
        //
        // }
        //
        // public List<Workout> GetAllWorkouts()
        // {
        //     return _context.Workouts.ToList();
        // }
        //
        // public Guid AddSet(Set set)
        // {
        //     _context.Sets.Add(set);
        //     _context.SaveChanges();
        //     var sid = set.Sid;
        //     return sid;  
        // }
        //
        // public void UpdateSet(Guid sid, Set set)
        // {
        //     var newSet = _context.Sets.FirstOrDefault<Set>(s => s.Sid == sid);
        //     if (newSet == null) return;
        //      newSet.Weight = set.Weight;
        //     newSet.Unit = set.Unit;
        //     newSet.Reps = set.Reps;
        //     newSet.Order = set.Order;
        //     newSet.Category = set.Category;
        //     newSet.Group = set.Group;
        //     // For now Sets cannot be moved between workouts
        //     // Maybe add a check to see if WorkoutId exists, and reassign them
        //
        //     _context.SaveChanges();
        // }
        //
        // public void DeleteSet(Guid sid)
        // {
        //     var set = _context.Sets.FirstOrDefault(s => s.Sid == sid);
        //     if (set == null) return;
        //     _context.Sets.Remove(set);
        //     _context.SaveChanges();
        // }
        //
        // public Set? GetSetById(Guid sid)
        // {
        //     var set = _context.Sets.FirstOrDefault(s => s.Sid == sid);
        //     return set != null ? set : null;
        // }
        //
        // public List<Set> GetAllSets()
        // {
        //     return _context.Sets.ToList();
        // }
   
        public Guid AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            Guid sid = user.Sid;
            return sid;   
        }

        public void UpdateUser(Guid sid, User updatedUser)
        {
            var user = _context.Users.FirstOrDefault<User>(u => u.Sid == sid);
            if (user != null)
            {
                user.Follows = updatedUser.Follows;
                user.Role = updatedUser.Role;
                _context.SaveChanges();
            }
        }

        public void DeleteUser(Guid sid)
        {
            var user = _context.Users.FirstOrDefault(u => u.Sid == sid);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }

        }

        public User? GetUserById(Guid sid)
        {
            var user = _context.Users.FirstOrDefault(u => u.Sid == sid);
            return user != null ? user : null;
        }

        public List<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }
     
       // public Guid AddRoutine(Routine routine)
       // {
       //     _context.Routines.Add(routine);
       //     _context.SaveChanges();
       //     Guid sid = routine.Sid;
       //     return sid; 
       // }
       //
       // public void UpdateRoutine(Guid sid, Routine routine)
       // {
       //     _context.Routines.FirstOrDefault<Routine>(r => r.Sid == sid);            
       //     _context.SaveChanges();
       // }
       //
       // public void DeleteRoutine(Guid sid)
       // {
       //     var routine = _context.Routines.FirstOrDefault(r => r.Sid == sid);
       //      if (routine != null)
       //      {
       //          _context.Routines.Remove(routine);
       //          _context.SaveChanges();
       //      }
       // }
       //
       // public Routine? GetRoutineById(Guid sid)
       // {
       //     return _context.Routines.FirstOrDefault(r => r.Sid == sid);
       // }
       //
       // public List<Routine> GetAllRoutines()
       // {
       //     return _context.Routines.ToList();
       //
       // }
    }
}