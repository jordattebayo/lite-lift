CREATE TABLE "roles" (
  "id" uuid UNIQUE DEFAULT uuid_generate_v4 () PRIMARY KEY,
  "type" varchar NOT NULL,
  "created_at" timestamp DEFAULT current_timestamp
);

CREATE TABLE "category" (
  "id" uuid UNIQUE DEFAULT uuid_generate_v4 () PRIMARY KEY,
  "type" varchar NOT NULL,
  "created_at" timestamp DEFAULT current_timestamp
);

CREATE TABLE "statuses" (
  "id" uuid UNIQUE DEFAULT uuid_generate_v4 () PRIMARY KEY,
  "type" varchar NOT NULL,
  "created_at" timestamp DEFAULT current_timestamp
);

CREATE TABLE "unit" (
  "id" uuid UNIQUE DEFAULT uuid_generate_v4 () PRIMARY KEY,
  "name" varchar NOT NULL,
  "created_at" timestamp DEFAULT current_timestamp
);

CREATE TABLE "users" (
  "id" uuid UNIQUE DEFAULT uuid_generate_v4 () PRIMARY KEY,
  "username" varchar UNIQUE NOT NULL,
  "role_id" uuid REFERENCES roles,
  "created_at" timestamp DEFAULT current_timestamp
);

CREATE TABLE "follows" (
  "id" BIGSERIAL PRIMARY KEY,
  "following_user_id" uuid REFERENCES users ON DELETE CASCADE,
  "followed_user_id" uuid REFERENCES users ON DELETE CASCADE,
  "created_at" timestamp DEFAULT current_timestamp
);

CREATE TABLE "workout" (
  "id" uuid UNIQUE DEFAULT uuid_generate_v4 () PRIMARY KEY,
  "notes" text,
  "user_id" uuid REFERENCES users ON DELETE CASCADE,
  "routine_id" uuid REFERENCES routine,
  "date" TIMESTAMP NOT NULL,
  "created_at" timestamp DEFAULT current_timestamp
);

CREATE TABLE "set" (
  "id" uuid UNIQUE DEFAULT uuid_generate_v4 () PRIMARY KEY,
  "weight" integer NOT NULL,
  "unit_id" uuid REFERENCES unit,
  "reps" integer NOT NULL,
  "order" integer,
  "workout_id" uuid ON DELETE CASCADE,
  "category_id" uuid REFERENCES category,
  "routine_id" uuid REFERENCES routine,
  "created_at" timestamp DEFAULT current_timestamp
);


CREATE TABLE "routine" (
  "id" uuid UNIQUE DEFAULT uuid_generate_v4 () PRIMARY KEY,
  "name" varchar NOT NULL,
  "notes" text,
  "status_id" uuid REFERENCES statuses,
  "created_at" timestamp DEFAULT current_timestamp
);

-- ALTER TABLE "workout" ADD FOREIGN KEY ("user_id") REFERENCES "users" ("sid");

-- ALTER TABLE "set" ADD FOREIGN KEY ("workout_id") REFERENCES "workout" ("sid");

-- ALTER TABLE "set" ADD FOREIGN KEY ("category_id") REFERENCES "category" ("sid");

-- ALTER TABLE "set" ADD FOREIGN KEY ("group_id") REFERENCES "routine" ("sid");

-- ALTER TABLE "set" ADD FOREIGN KEY ("unit_id") REFERENCES "unit" ("sid");

-- ALTER TABLE "routine" ADD FOREIGN KEY ("status_id") REFERENCES "status" ("sid");

-- ALTER TABLE "workout" ADD FOREIGN KEY ("group_id") REFERENCES "routine" ("sid");

-- ALTER TABLE "follows" ADD FOREIGN KEY ("following_user_id") REFERENCES "users" ("sid");

-- ALTER TABLE "follows" ADD FOREIGN KEY ("followed_user_id") REFERENCES "users" ("sid");

-- ALTER TABLE "users" ADD FOREIGN KEY ("role_id") REFERENCES "roles" ("sid");

