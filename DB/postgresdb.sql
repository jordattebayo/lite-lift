CREATE TABLE "follows" (
  "id" BIGSERIAL PRIMARY KEY,
  "following_user_id" uuid NOT NULL,
  "followed_user_id" uuid NOT NULL,
  "created_at" timestamp DEFAULT current_timestamp
);

CREATE TABLE "users" (
  "id" BIGSERIAL PRIMARY KEY,
  "sid" uuid UNIQUE DEFAULT uuid_generate_v4 (),
  "username" varchar UNIQUE NOT NULL,
  "role_id" uuid NOT NULL,
  "created_at" timestamp DEFAULT current_timestamp
);

CREATE TABLE "roles" (
  "id" BIGSERIAL PRIMARY KEY,
  "sid" uuid UNIQUE DEFAULT uuid_generate_v4 (),
  "type" varchar NOT NULL,
  "created_at" timestamp DEFAULT current_timestamp
)

CREATE TABLE "workout" (
  "id" integer PRIMARY KEY,
  "sid" uuid UNIQUE DEFAULT uuid_generate_v4 (),
  "notes" text,
  "user_id" uuid NOT NULL,
  "group_id" uuid,
  "date" TIMESTAMP NOT NULL,
  "created_at" timestamp DEFAULT current_timestamp
);

CREATE TABLE "set" (
  "id" BIGSERIAL PRIMARY KEY,
  "sid" uuid UNIQUE DEFAULT uuid_generate_v4 (),
  "weight" integer NOT NULL,
  "unit_id" uuid,
  "reps" integer NOT NULL,
  "order" integer,
  "workout_id" uuid,
  "category_id" uuid NOT NULL,
  "group_id" uuid,
  "created_at" timestamp DEFAULT current_timestamp
);

CREATE TABLE "category" (
  "id" BIGSERIAL PRIMARY KEY,
  "sid" uuid UNIQUE DEFAULT uuid_generate_v4 (),
  "type" varchar NOT NULL,
  "created_at" timestamp DEFAULT current_timestamp
);

CREATE TABLE "unit" (
  "id" BIGSERIAL PRIMARY KEY,
  "sid" uuid UNIQUE DEFAULT uuid_generate_v4 (),
  "name" varchar NOT NULL,
  "created_at" timestamp DEFAULT current_timestamp
);

CREATE TABLE "groups" (
  "id" BIGSERIAL PRIMARY KEY,
  "sid" uuid UNIQUE DEFAULT uuid_generate_v4 (),
  "name" varchar NOT NULL,
  "notes" text,
  "status_id" uuid NOT NULL,
  "created_at" timestamp DEFAULT current_timestamp
);

CREATE TABLE "status" (
  "id" BIGSERIAL PRIMARY KEY,
  "sid" uuid UNIQUE DEFAULT uuid_generate_v4 (),
  "type" varchar NOT NULL,
  "created_at" timestamp DEFAULT current_timestamp
);

ALTER TABLE "workout" ADD FOREIGN KEY ("user_id") REFERENCES "users" ("sid");

ALTER TABLE "set" ADD FOREIGN KEY ("workout_id") REFERENCES "workout" ("sid");

ALTER TABLE "set" ADD FOREIGN KEY ("category_id") REFERENCES "category" ("sid");

ALTER TABLE "set" ADD FOREIGN KEY ("group_id") REFERENCES "groups" ("sid");

ALTER TABLE "set" ADD FOREIGN KEY ("unit_id") REFERENCES "unit" ("sid");

ALTER TABLE "groups" ADD FOREIGN KEY ("status_id") REFERENCES "status" ("sid");

ALTER TABLE "workout" ADD FOREIGN KEY ("group_id") REFERENCES "groups" ("sid");

ALTER TABLE "follows" ADD FOREIGN KEY ("following_user_id") REFERENCES "users" ("sid");

ALTER TABLE "follows" ADD FOREIGN KEY ("followed_user_id") REFERENCES "users" ("sid");

ALTER TABLE "users" ADD FOREIGN KEY ("role_id") REFERENCES "roles" ("sid");

