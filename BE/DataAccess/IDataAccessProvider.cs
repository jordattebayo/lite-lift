using BE.Models;
using System.Collections.Generic;

namespace BE.DataAccess
{ 
    public interface IDataAccessProvider
    {
        Guid AddWorkout(Workout workout);
        void UpdateWorkout(Guid id, Workout workout);
        void DeleteWorkout(Guid id);
        Workout? GetWorkoutById(Guid id);
        List<Workout> GetAllWorkouts();

        Guid AddSet(Set set);
        void UpdateSet(Guid sid, Set set);
        void DeleteSet(Guid sid);
        Set? GetSetById(Guid sid);
        List<Set> GetAllSets();

        Guid AddUser(User user);
        void UpdateUser(Guid sid, User user);
        void DeleteUser(Guid sid);
        User? GetUserById(Guid sid);
        List<User> GetAllUsers();

        Guid AddRoutine(Routine routine);
        void UpdateRoutine(Guid sid, Routine routine);
        void DeleteRoutine(Guid sid);
        Routine? GetRoutineById(Guid sid);
        List<Routine> GetAllRoutines();

    }
}