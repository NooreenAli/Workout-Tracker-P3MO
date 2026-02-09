"use client";

import { useEffect, useState } from "react";
import Link from "next/link";

export default function SessionsPage() {
    const [sessions, setSessions] = useState<any[]>([]);
    const [expandedId, setExpandedId] = useState<number | null>(null);
    const [message, setMessage] = useState<string | null>(null);

    async function loadSessions() {
        const res = await fetch("/api/sessions");
        const data = await res.json();
        setSessions(data);
    }

    useEffect(() => {
        loadSessions();
    }, []);

    const handleDelete = async (id: number) => {
        const res = await fetch(`/api/sessions/${id}`, {
            method: "DELETE",
        });

        if (res.ok) {
            setSessions((prev) => prev.filter((s) => s.id !== id));
            setMessage("Session deleted successfully.");
        }
    };

    const handleUpdate = async (session: any) => {
        const res = await fetch(`/api/sessions/${session.id}`, {
            method: "PUT",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(session),
        });

        if (res.ok) {
            setMessage("Session updated successfully.");
            setExpandedId(null);
            loadSessions();
        }
    };

    const updateSetField = (
        sessionId: number,
        setIndex: number,
        field: string,
        value: any
    ) => {
        setSessions((prev) =>
            prev.map((s) =>
                s.id === sessionId
                    ? {
                        ...s,
                        sets: s.sets.map((set: any, i: number) =>
                            i === setIndex
                                ? { ...set, [field]: value }
                                : set
                        ),
                    }
                    : s
            )
        );
    };

    return (
        <div className="max-w-5xl mx-auto p-8 space-y-6">
            <div className="flex justify-between items-center">
                <h1 className="text-3xl font-semibold">
                    Workout Sessions
                </h1>

                <div className="flex gap-3">
                    <Link
                        href="/"
                        className="bg-gray-200 px-4 py-2 rounded hover:bg-gray-300 transition"
                    >
                        Back to Home
                    </Link>

                    <Link
                        href="/sessions/new"
                        className="bg-blue-600 text-white px-4 py-2 rounded hover:bg-blue-700 transition"
                    >
                        Record Session
                    </Link>
                </div>
            </div>


            {message && (
                <div className="bg-green-100 text-green-800 p-3 rounded">
                    {message}
                </div>
            )}

            <div className="space-y-4">
                {sessions.map((session) => {
                    const started = new Date(session.startedAt);

                    return (
                        <div
                            key={session.id}
                            className="bg-white border rounded p-4 shadow-sm"
                        >
                            <div className="flex justify-between items-start">
                                <div className="space-y-1">
                                    <div className="font-semibold text-lg">
                                        {started.toLocaleDateString()}
                                    </div>

                                    <div className="text-sm text-gray-600">
                                        {started.toLocaleTimeString()}
                                    </div>

                                    <div className="text-sm">
                                        Duration: {session.durationMinutes} mins
                                    </div>

                                    <div className="text-sm">
                                        Total Sets: {session.totalSets}
                                    </div>
                                </div>

                                <div className="flex gap-3">
                                    <Link
                                        href={`/sessions/${session.id}`}
                                        className="text-blue-600 hover:underline"
                                    >
                                        Edit
                                    </Link>

                                    <button
                                        onClick={() => handleDelete(session.id)}
                                        className="text-red-600 hover:underline"
                                    >
                                        Delete
                                    </button>
                                </div>
                            </div>
                        </div>
                    );
                })}


            </div>
        </div>
    );
}