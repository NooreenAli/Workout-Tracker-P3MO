export async function GET() {
  const res = await fetch(
    `${process.env.BACKEND_URL}/api/analytics/volume-by-session`,
    {
      headers: {
        "X-API-KEY": process.env.API_KEY as string,
      },
    }
  );

  const data = await res.json();
  return Response.json(data);
}