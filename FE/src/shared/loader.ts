import { Session } from "./types";


export async function loader() {
    const sessions: Session[] = [
        {
          id: '1',
          date: '01-02-2024',
          notes: 'Tough one',
          user_id: '001',
          status: 'complete',
          group: 'A',
          workouts: [
            {
              id: '1',
              activity: 'squat',
              reps: 4,
              sets: 4,
              weight: {
                value: 135,
                unit: 'lbs',
              },
            },
            {
              id: '2',
              activity: 'deadlift',
              reps: 2,
              sets: 4,
              weight: {
                value: 195,
                unit: 'lbs',
              },
            },
          ],
        },
        {
          id: '2',
          date: '01-04-2024',
          notes: 'Light work',
          user_id: '001',
          status: 'complete',
          group: 'B',
          workouts: [
            {
              id: '3',
              activity: 'squat',
              reps: 4,
              sets: 4,
              weight: {
                value: 135,
                unit: 'lbs',
              },
            },
            {
              id: '4',
              activity: 'deadlift',
              reps: 2,
              sets: 4,
              weight: {
                value: 195,
                unit: 'lbs',
              },
            },
          ],
        },
        {
          id: '3',
          date: '01-06-2024',
          notes: 'Okay',
          user_id: '001',
          status: 'complete',
          group: 'Mixed',
          workouts: [
            {
              id: '5',
              activity: 'squat',
              reps: 4,
              sets: 4,
              weight: {
                value: 135,
                unit: 'lbs',
              },
            },
            {
              id: '6',
              activity: 'deadlift',
              reps: 2,
              sets: 4,
              weight: {
                value: 195,
                unit: 'lbs',
              },
            },
          ],
        },
        {
          id: '4',
          date: '01-08-2024',
          notes: 'Okay okay',
          user_id: '001',
          status: 'complete',
          group: 'A',
          workouts: [
            {
              id: '7',
              activity: 'squat',
              reps: 4,
              sets: 4,
              weight: {
                value: 135,
                unit: 'lbs',
              },
            },
            {
              id: '8',
              activity: 'deadlift',
              reps: 2,
              sets: 4,
              weight: {
                value: 195,
                unit: 'lbs',
              },
            },
          ],
        },
      ];

      function getSessions() {
        return fetchMockData()
                .then(data => console.log(data))
                .catch(error => console.error(error))
      }
      
      function fetchMockData() {
        return new Promise((resolve) => {
          setTimeout(() => {
              resolve(sessions);
          }, 2000);
        });
      }

    const res = await getSessions();
    return { res };
  }