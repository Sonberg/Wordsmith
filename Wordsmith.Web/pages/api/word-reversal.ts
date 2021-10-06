import axios, { Method } from "axios";
import type { NextApiRequest, NextApiResponse } from "next";

const ApiClient = axios.create({
  baseURL: process.env.API_URL,
});

function getMethod(req: NextApiRequest): Method {
  return req.method as Method;
}

function getTask(req: NextApiRequest) {
  return ApiClient({
    url: req.url?.substring(4),
    data: req.body,
    method: getMethod(req),
    validateStatus: () => true,
  });
}

export default async function wordReversal(
  req: NextApiRequest,
  res: NextApiResponse<unknown>
) {
  const response = await getTask(req);

  res.status(response.status);
  res.json(response.data);
}
