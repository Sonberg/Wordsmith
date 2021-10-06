import axios, { AxiosResponse } from "axios";

const client = axios.create({
  baseURL: process.env.API_URL,
});

type Request = {
  input: string;
};

type Response = AxiosResponse<{
  input: string;
  result: string;
}>;

export async function reverseSentence(input: string) {
  const { data } = await client.post<Request, Response>("/api/word-reversal", {
    input,
  });

  return data.result;
}
