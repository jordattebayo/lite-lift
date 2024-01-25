using BE.Models;
using System.Collections.Generic;
using System.Linq;

namespace BE.DataAccess;

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
        Guid sid = workout.sid;
        return sid;
    }

    public void UpdateWorkout(Guid sid, Workout updatedWorkout)
    {
        _context.Workouts.FirstOrDefault<Workout>(w => w.sid == sid);            
        _context.SaveChanges();
    }

    public void DeleteWorkout(Guid sid)
    {
        var workout = _context.Workouts.FirstOrDefault(w => w.sid == sid);
        _context.Workouts.Remove(workout);
        _context.SaveChanges();
    }

    public Workout GetWorkoutById(Guid id)
    {
        return _context.Workouts.FirstOrDefault(w => w.sid == sid);
    }

    public List<Workout> GetAllWorkouts()
    {
        return _context.Workouts.ToList();
    }

    public Guid AddSet(Set set)
    {
        _context.Sets.Add(set);
        _context.SaveChanges();
        Guid sid = set.sid;
        return sid;  
    }

    public void UpdateSet(Guid sid, Set set)
    {
        _context.Sets.FirstOrDefault<Set>(s => s.sid == sid);            
        _context.SaveChanges();
    }

    public void DeleteSet(Guid sid)
    {
        var set = _context.Sets.FirstOrDefault(s => s.sid == sid);
        _context.Sets.Remove(set);
        _context.SaveChanges();
    }
    
    public Set GetSetById(Guid sid){}
    {
        return _context.Sets.FirstOrDefault(s => s.sid == sid);
    }

    public List<Set> GetAllSets()
    {
        return _context.Sets.ToList();
    }

    public Guid AddUser(User user)
    {
        _context.User.Add(user);
        _context.SaveChanges();
        Guid sid = user.sid;
        return sid;   
    }

    public void UpdateUser(Guid sid, User user)
    {
        _context.Users.FirstOrDefault<User>(u => u.sid == sid);            
        _context.SaveChanges();
    }

    public void DeleteUser(Guid sid)
    {
        var user = _context.Users.FirstOrDefault(u => u.sid == sid);
        _context.Users.Remove(user);
        _context.SaveChanges();
    }

    public User GetUserById(Guid sid)
    {
        return _context.Users.FirstOrDefault(u => u.sid == sid);
    }

    public List<User> GetAllUsers()
    {
        return _context.Users.ToList();
    }

    public Guid AddRoutine(Routine routine)
    {
        _context.Routine.Add(routine);
        _context.SaveChanges();
        Guid sid = routine.sid;
        return sid; 
    }

    public void UpdateRoutine(Guid sid, Routine routine)
    {
        _context.Routines.FirstOrDefault<Routine>(r => r.sid == sid);            
        _context.SaveChanges();
    }

    public void DeleteRoutine(Guid sid)
    {
        var routine = _context.Routines.FirstOrDefault(r => r.sid == sid);
        _context.Users.Remove(routine);
        _context.SaveChanges();
    }

    public Routine GetRoutineById(Guid sid)
    {
        return _context.Routines.FirstOrDefault(r => r.sid == sid);
    }

    public List<Routine> GetAllRoutines()
    {
        return _context.Routines.ToList();

    }
}