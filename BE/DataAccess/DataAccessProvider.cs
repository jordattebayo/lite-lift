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

        public Guid AddWorkout(Workout workout)
        {
            _context.Workout.Add(workout);
            _context.SaveChanges();
            Guid sid = workout.Sid;
            return sid;
        }

        public void UpdateWorkout(Guid sid, Workout updatedWorkout)
        {
            var workout = _context.Workout.FirstOrDefault<Workout>(w => w.Sid == sid);
            if (workout == null) return;
            workout.Notes = updatedWorkout.Notes;
            workout.Date = updatedWorkout.Date;
            workout.UserId = updatedWorkout.UserId;
            workout.GroupId = updatedWorkout.GroupId;
            _context.SaveChanges();
        }

        public void DeleteWorkout(Guid sid)
        {
            var workout = _context.Workout.FirstOrDefault(w => w.Sid == sid);
            if (workout != null)
            {
                _context.Workout.Remove(workout);
                _context.SaveChanges();
            }
        }

        public Workout? GetWorkoutById(Guid sid)
        {
            var workout = _context.Workout.FirstOrDefault(w => w.Sid == sid);
            return workout;

        }

        public List<Workout> GetAllWorkouts()
        {
            return _context.Workout.ToList();
        }

        public Guid AddSet(Set set)
        {
            _context.Set.Add(set);
            _context.SaveChanges();
            var sid = set.Sid;
            return sid;
        }

        public void UpdateSet(Guid sid, Set set)
        {
            var newSet = _context.Set.FirstOrDefault<Set>(s => s.Sid == sid);
            if (newSet == null) return;
            newSet.Weight = set.Weight;
            newSet.UnitId = set.UnitId;
            newSet.Reps = set.Reps;
            newSet.Order = set.Order;
            newSet.CategoryId = set.CategoryId;
            newSet.GroupId = set.GroupId;
            // For now Sets cannot be moved between workouts
            // Maybe add a check to see if WorkoutId exists, and reassign them

            _context.SaveChanges();
        }

        public void DeleteSet(Guid sid)
        {
            var set = _context.Set.FirstOrDefault(s => s.Sid == sid);
            if (set == null) return;
            _context.Set.Remove(set);
            _context.SaveChanges();
        }

        public Set? GetSetById(Guid sid)
        {
            var set = _context.Set.FirstOrDefault(s => s.Sid == sid);
            return set != null ? set : null;
        }

        public List<Set> GetAllSets()
        {
            return _context.Set.ToList();
        }

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
                user.Username = updatedUser.Username;
                user.RoleId = updatedUser.RoleId;
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

        public Guid AddRoutine(Routine routine)
        {
            _context.Routine.Add(routine);
            _context.SaveChanges();
            Guid sid = routine.Sid;
            return sid;
        }

        public void UpdateRoutine(Guid sid, Routine updatedRoutine)
        {
            var routine = _context.Routine.FirstOrDefault<Routine>(r => r.Sid == sid);
            if(routine != null)
            {
                routine.Name = updatedRoutine.Name;
                routine.StatusId = updatedRoutine.StatusId;
                routine.Notes = updatedRoutine.Notes;
            }
            _context.SaveChanges();
        }

        public void DeleteRoutine(Guid sid)
        {
            var routine = _context.Routine.FirstOrDefault(r => r.Sid == sid);
            if (routine != null)
            {
                _context.Routine.Remove(routine);
                _context.SaveChanges();
            }
        }

        public Routine? GetRoutineById(Guid sid)
        {
            return _context.Routine.FirstOrDefault(r => r.Sid == sid);
        }

        public List<Routine> GetAllRoutines()
        {
            return _context.Routine.ToList();

        }
    }
}