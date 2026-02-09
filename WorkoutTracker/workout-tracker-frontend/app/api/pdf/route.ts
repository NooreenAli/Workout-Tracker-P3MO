export async function POST(req: Request) {
  const { url } = await req.json();

  const res = await fetch(
    `${process.env.BACKEND_URL}/api/pdf/generate`,
    {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
        "X-API-KEY": process.env.API_KEY as string,
      },
      body: JSON.stringify({ url }),
    }
  );

  const buffer = await res.arrayBuffer();

  return new Response(buffer, {
    headers: {
      "Content-Type": "application/pdf",
      "Content-Disposition": "attachment; filename=workout-report.pdf",
    },
  });
}