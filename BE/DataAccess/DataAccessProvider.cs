using BE.Models;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace BE.DataAccess
{
    public class DataAccessProvider : IDataAccessProvider
    {
        private readonly LiteliftdevContext _context;

        public DataAccessProvider(LiteliftdevContext context)
        {
            _context = context;
        }

        public Guid AddWorkout(Workout workout)
        {
            _context.Workouts.Add(workout);
            _context.SaveChanges();
            Guid sid = workout.Id;
            return sid;
        }

        public void UpdateWorkout(Guid id, Workout updatedWorkout)
        {
            var workout = _context.Workouts.FirstOrDefault<Workout>(w => w.Id == id);
            if (workout == null) return;
            workout.Notes = updatedWorkout.Notes;
            workout.Date = updatedWorkout.Date;
            workout.UserId = updatedWorkout.UserId;
            workout.RoutineId = updatedWorkout.RoutineId;
            _context.SaveChanges();
        }

        public void DeleteWorkout(Guid id)
        {
            var workout = _context.Workouts.FirstOrDefault(w => w.Id == id);
            if (workout != null)
            {
                _context.Workouts.Remove(workout);
                _context.SaveChanges();
            }
        }

        public Workout? GetWorkoutById(Guid id)
        {
            var workout = _context.Workouts.FirstOrDefault(w => w.Id == id);
            return workout;

        }

        public List<Workout> GetAllWorkouts()
        {
            return _context.Workouts.ToList();
        }

        public Guid AddSet(Set set)
        {
            _context.Sets.Add(set);
            _context.SaveChanges();
            var id = set.Id;
            return id;
        }

        public void UpdateSet(Guid id, Set set)
        {
            var newSet = _context.Sets.FirstOrDefault<Set>(s => s.Id == id);
            if (newSet == null) return;
            newSet.Weight = set.Weight;
            newSet.UnitId = set.UnitId;
            newSet.Reps = set.Reps;
            newSet.Order = set.Order;
            newSet.CategoryId = set.CategoryId;
            newSet.RoutineId = set.RoutineId;
            // For now Sets cannot be moved between workouts
            // Maybe add a check to see if WorkoutId exists, and reassign them

            _context.SaveChanges();
        }

        public void DeleteSet(Guid id)
        {
            var set = _context.Sets.FirstOrDefault(s => s.Id == id);
            if (set == null) return;
            _context.Sets.Remove(set);
            _context.SaveChanges();
        }

        public Set? GetSetById(Guid id)
        {
            var set = _context.Sets.FirstOrDefault(s => s.Id == id);
            return set != null ? set : null;
        }

        public List<Set> GetAllSets()
        {
            return _context.Sets.ToList();
        }

        public Guid AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            Guid id = user.Id;
            return id;
        }

        public void UpdateUser(Guid id, User updatedUser)
        {
            var user = _context.Users.FirstOrDefault<User>(u => u.Id == id);
            if (user != null)
            {
                user.Username = updatedUser.Username;
                user.RoleId = updatedUser.RoleId;
                _context.SaveChanges();
            }
        }

        public void DeleteUser(Guid id)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == id);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }

        }

        public User? GetUserById(Guid id)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == id);
            return user != null ? user : null;
        }

        public List<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }

        public Guid AddRoutine(Routine routine)
        {
            _context.Routines.Add(routine);
            _context.SaveChanges();
            Guid sid = routine.Id;
            return sid;
        }

        public void UpdateRoutine(Guid id, Routine updatedRoutine)
        {
            var routine = _context.Routines.FirstOrDefault<Routine>(r => r.Id == id);
            if(routine != null)
            {
                routine.Name = updatedRoutine.Name;
                routine.StatusId = updatedRoutine.StatusId;
                routine.Notes = updatedRoutine.Notes;
            }
            _context.SaveChanges();
        }

        public void DeleteRoutine(Guid id)
        {
            var routine = _context.Routines.FirstOrDefault(r => r.Id == id);
            if (routine != null)
            {
                _context.Routines.Remove(routine);
                _context.SaveChanges();
            }
        }

        public Routine? GetRoutineById(Guid id)
        {
            return _context.Routines.FirstOrDefault(r => r.Id == id);
        }

        public List<Routine> GetAllRoutines()
        {
            return _context.Routines.ToList();

        }
    }
}