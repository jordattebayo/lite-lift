type Workout = {
    id: string;
    activity: string;
    reps: number;
    sets: number;
    weight: {
      value: number;
      unit: 'lbs' | 'kilos';
    };
  };
  
  export type Session = {
    id: string;
    date: string;
    notes: string;
    user_id: string;
    status: 'draft' | 'complete' | 'in-progress';
    group: 'A' | 'B' | 'Mixed';
    workouts: Workout[];
  };