"use client";

import { useEffect, useState } from "react";
import ReactECharts from "echarts-for-react";
import Link from "next/link";

export default function Home() {
  const [volumeData, setVolumeData] = useState<any[]>([]);
  const [exerciseData, setExerciseData] = useState<any[]>([]);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    async function loadData() {
      try {
        const volumeRes = await fetch("/api/analytics/volume-by-session");
        const exerciseRes = await fetch("/api/analytics/sets-by-exercise");

        if (!volumeRes.ok || !exerciseRes.ok) {
          throw new Error("Analytics fetch failed");
        }

        const volume = await volumeRes.json();
        const exercises = await exerciseRes.json();

        setVolumeData(volume);
        setExerciseData(exercises);
      } catch (err) {
        console.error(err);
      } finally {
        setLoading(false);
      }
    }

    loadData();
  }, []);

  const volumeChartOptions = {
    title: { text: "Volume Per Session" },
    tooltip: { trigger: "axis" },
    xAxis: {
      type: "category",
      data: volumeData.map((d) =>
        new Date(d.startedAt).toLocaleDateString()
      ),
    },
    yAxis: { type: "value" },
    series: [
      {
        data: volumeData.map((d) => d.totalVolume),
        type: "line",
        smooth: true,
      },
    ],
  };

  const exerciseChartOptions = {
    title: { text: "Total Sets Per Exercise" },
    tooltip: { trigger: "axis" },
    xAxis: {
      type: "category",
      data: exerciseData.map((d) => d.exerciseName),
    },
    yAxis: { type: "value" },
    series: [
      {
        data: exerciseData.map((d) => d.totalSets),
        type: "bar",
      },
    ],
  };

  const handleDownloadPdf = async () => {
    const currentUrl =
      window.location.origin + window.location.pathname;

    const res = await fetch("/api/pdf", {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify({ url: currentUrl }),
    });

    const blob = await res.blob();
    const fileUrl = window.URL.createObjectURL(blob);

    const a = document.createElement("a");
    a.href = fileUrl;
    a.download = "workout-report.pdf";
    a.click();

    window.URL.revokeObjectURL(fileUrl);
  };

  return (
    <div className="max-w-5xl mx-auto p-8 space-y-8">
      <div className="flex justify-between items-center">
        <h1 className="text-3xl font-semibold">
          Workout Analytics Dashboard
        </h1>

        <div className="flex gap-3">
          <Link
            href="/sessions"
            className="bg-gray-200 px-4 py-2 rounded hover:bg-gray-300 transition"
          >
            View Sessions
          </Link>

          <Link
            href="/sessions/new"
            className="bg-blue-600 text-white px-4 py-2 rounded hover:bg-blue-700 transition"
          >
            Record Session
          </Link>

          <button
            onClick={handleDownloadPdf}
            className="bg-gray-800 text-white px-4 py-2 rounded hover:bg-gray-900 transition"
          >
            Download PDF
          </button>
        </div>

      </div>

      {loading ? (
        <div className="text-gray-600">
          Loading analytics...
        </div>
      ) : (
        <>
          <div className="bg-white p-6 rounded shadow-sm">
            <ReactECharts option={volumeChartOptions} />
          </div>

          <div className="bg-white p-6 rounded shadow-sm">
            <ReactECharts option={exerciseChartOptions} />
          </div>
        </>
      )}
    </div>
  );
}