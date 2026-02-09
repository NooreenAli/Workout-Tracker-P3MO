export async function GET() {
  const res = await fetch(
    `${process.env.BACKEND_URL}/api/exercises`,
    {
      headers: {
        "X-API-KEY": process.env.API_KEY as string,
      },
    }
  );

  if (!res.ok) {
    return new Response("Failed to fetch exercises", {
      status: res.status,
    });
  }

  const data = await res.json();
  return Response.json(data);
}