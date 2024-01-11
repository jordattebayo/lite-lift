-- need to assign NOT NULL to specific columns
-- need to add function to generate UUID on insert
-- need to add enum/table for status in group
-- need to add function to generate timestamp for all created_at

CREATE TABLE "follows" (
  "id" integer PRIMARY KEY,
  "following_user_id" uuid,
  "followed_user_id" uuid,
  "created_at" timestamp
);

CREATE TABLE "users" (
  "id" integer PRIMARY KEY,
  "sid" uuid UNIQUE,
  "username" varchar,
  "role" varchar,
  "created_at" timestamp
);

CREATE TABLE "workout" (
  "id" integer PRIMARY KEY,
  "sid" uuid UNIQUE,
  "notes" text,
  "user_id" uuid,
  "group_id" uuid,
  "created_at" timestamp
);

CREATE TABLE "set" (
  "id" integer PRIMARY KEY,
  "sid" uuid UNIQUE,
  "weight" integer,
  "unit_id" uuid,
  "reps" integer,
  "order" integer,
  "workout_id" uuid,
  "category_id" uuid,
  "group_id" uuid,
  "created_at" timestamp
);

CREATE TABLE "category" (
  "id" integer PRIMARY KEY,
  "sid" uuid UNIQUE,
  "type" varchar,
  "created_at" timestamp
);

CREATE TABLE "unit" (
  "id" integer PRIMARY KEY,
  "sid" uuid UNIQUE,
  "name" varchar,
  "created_at" timestamp
);

CREATE TABLE "group" (
  "id" integer PRIMARY KEY,
  "sid" uuid UNIQUE,
  "name" varchar,
  "notes" text,
  "status" varchar,
  "created_at" timestamp
);

ALTER TABLE "workout" ADD FOREIGN KEY ("user_id") REFERENCES "users" ("sid");

ALTER TABLE "set" ADD FOREIGN KEY ("workout_id") REFERENCES "workout" ("sid");

ALTER TABLE "set" ADD FOREIGN KEY ("category_id") REFERENCES "category" ("sid");

ALTER TABLE "set" ADD FOREIGN KEY ("group_id") REFERENCES "group" ("sid");

ALTER TABLE "set" ADD FOREIGN KEY ("unit_id") REFERENCES "unit" ("sid");

ALTER TABLE "workout" ADD FOREIGN KEY ("group_id") REFERENCES "group" ("sid");

ALTER TABLE "follows" ADD FOREIGN KEY ("following_user_id") REFERENCES "users" ("sid");

ALTER TABLE "follows" ADD FOREIGN KEY ("followed_user_id") REFERENCES "users" ("sid");
