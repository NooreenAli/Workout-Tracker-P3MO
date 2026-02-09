export async function GET(
  req: Request,
  context: { params: Promise<{ id: string }> }
) {
  const { id } = await context.params;

  const res = await fetch(
    `${process.env.BACKEND_URL}/api/sessions/${id}`,
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

export async function PUT(
  req: Request,
  context: { params: Promise<{ id: string }> }
) {
  const { id } = await context.params;
  const body = await req.json();

  const res = await fetch(
    `${process.env.BACKEND_URL}/api/sessions/${id}`,
    {
      method: "PUT",
      headers: {
        "Content-Type": "application/json",
        "X-API-KEY": process.env.API_KEY as string,
      },
      body: JSON.stringify(body),
    }
  );

  return new Response(null, { status: res.status });
}

export async function DELETE(
  req: Request,
  context: { params: Promise<{ id: string }> }
) {
  const { id } = await context.params;

  const res = await fetch(
    `${process.env.BACKEND_URL}/api/sessions/${id}`,
    {
      method: "DELETE",
      headers: {
        "X-API-KEY": process.env.API_KEY as string,
      },
    }
  );

  return new Response(null, { status: res.status });
}