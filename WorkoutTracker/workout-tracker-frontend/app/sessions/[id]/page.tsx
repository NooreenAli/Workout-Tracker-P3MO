"use client";

import { useEffect, useState } from "react";
import { useParams, useRouter } from "next/navigation";
import { useForm, useFieldArray } from "react-hook-form";
import { z } from "zod";
import { zodResolver } from "@hookform/resolvers/zod";
import Link from "next/link";

const setSchema = z.object({
  exerciseId: z.number(),
  reps: z.number().min(1, "Reps must be at least 1"),
  weightKg: z
    .number()
    .min(0, "Weight cannot be negative")
    .max(9999.99, "Max weight is 9999.99")
    .refine((val) => Number(val.toFixed(2)) === val, {
      message: "Maximum 2 decimal places allowed",
    }),
});

const formSchema = z.object({
  sets: z.array(setSchema).min(1, "At least one set required"),
});

type FormData = z.infer<typeof formSchema>;

export default function EditSessionPage() {
  const { id } = useParams();
  const router = useRouter();

  const [exercises, setExercises] = useState<any[]>([]);
  const [message, setMessage] = useState<string | null>(null);

  const {
    register,
    control,
    handleSubmit,
    reset,
    formState: { errors },
  } = useForm<FormData>({
    resolver: zodResolver(formSchema),
  });

  const { fields, append, remove } = useFieldArray({
    control,
    name: "sets",
  });

  useEffect(() => {
    async function loadData() {
      const [sessionRes, exercisesRes] = await Promise.all([
        fetch(`/api/sessions/${id}`),
        fetch("/api/exercises"),
      ]);

      const session = await sessionRes.json();
      const exercises = await exercisesRes.json();

      setExercises(exercises);

      reset({
        sets: session.sets,
      });
    }

    loadData();
  }, [id, reset]);

  const onSubmit = async (data: FormData) => {
    const res = await fetch(`/api/sessions/${id}`, {
      method: "PUT",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify(data),
    });

    if (res.ok) {
      setMessage("Session updated successfully.");
      setTimeout(() => router.push("/sessions"), 1000);
    } else {
      setMessage("Failed to update session.");
    }
  };

  return (
    <div className="max-w-3xl mx-auto p-8 space-y-6">
      <div className="flex justify-between items-center">
        <h1 className="text-3xl font-semibold">
          Edit Session
        </h1>

        <Link
          href="/sessions"
          className="text-blue-600 hover:underline"
        >
          Back to Sessions
        </Link>
      </div>

      {message && (
        <div className="bg-green-100 text-green-800 p-3 rounded">
          {message}
        </div>
      )}

      <form
        onSubmit={handleSubmit(onSubmit)}
        className="space-y-6"
      >
        {fields.map((field, index) => (
          <div
            key={field.id}
            className="bg-white border rounded p-4 shadow-sm space-y-3"
          >
            <div>
              <label className="block text-sm mb-1">
                Exercise
              </label>
              <select
                {...register(`sets.${index}.exerciseId`, {
                  valueAsNumber: true,
                })}
                className="border rounded p-2 w-full"
              >
                {exercises.map((e) => (
                  <option key={e.id} value={e.id}>
                    {e.name}
                  </option>
                ))}
              </select>
            </div>

            <div>
              <label className="block text-sm mb-1">
                Reps
              </label>
              <input
                type="number"
                {...register(`sets.${index}.reps`, {
                  valueAsNumber: true,
                })}
                className="border rounded p-2 w-full"
              />
              {errors.sets?.[index]?.reps && (
                <p className="text-red-600 text-sm">
                  {errors.sets[index]?.reps?.message}
                </p>
              )}
            </div>

            <div>
              <label className="block text-sm mb-1">
                Weight (kg)
              </label>
              <input
                type="number"
                step="0.01"
                {...register(`sets.${index}.weightKg`, {
                  valueAsNumber: true,
                })}
                className="border rounded p-2 w-full"
              />
              {errors.sets?.[index]?.weightKg && (
                <p className="text-red-600 text-sm">
                  {errors.sets[index]?.weightKg?.message}
                </p>
              )}
            </div>

            {fields.length > 1 && (
              <button
                type="button"
                onClick={() => remove(index)}
                className="text-red-600 text-sm hover:underline"
              >
                Remove Set
              </button>
            )}
          </div>
        ))}

        <button
          type="button"
          onClick={() =>
            append({ exerciseId: 1, reps: 1, weightKg: 0 })
          }
          className="bg-gray-200 px-4 py-2 rounded hover:bg-gray-300 transition"
        >
          Add Another Set
        </button>

        <button
          type="submit"
          className="bg-blue-600 text-white px-6 py-2 rounded hover:bg-blue-700 transition"
        >
          Save Changes
        </button>
      </form>
    </div>
  );
}