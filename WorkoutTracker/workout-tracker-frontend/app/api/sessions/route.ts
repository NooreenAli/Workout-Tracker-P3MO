export async function GET() {
  const res = await fetch(
    `${process.env.BACKEND_URL}/api/sessions`,
    {
      headers: {
        "X-API-KEY": process.env.API_KEY as string,
      },
    }
  );

  if (!res.ok) {
    return new Response("Backend error", { status: res.status });
  }

  const data = await res.json();
  return Response.json(data);
}

export async function POST(req: Request) {
  const body = await req.json();

  const res = await fetch(
    `${process.env.BACKEND_URL}/api/sessions`,
    {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
        "X-API-KEY": process.env.API_KEY as string,
      },
      body: JSON.stringify(body),
    }
  );

  return new Response(null, { status: res.status });
}