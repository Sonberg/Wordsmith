import axios, { AxiosResponse } from "axios";

const client = axios.create({
  baseURL: "http://localhost:7272",
});

type ReverseSentenceRequest = {
  input: string;
};

type ReverseSentenceResponse = AxiosResponse<{
  input: string;
  result: string;
}>;

export async function reverseSentence(input: string) {
  const { data } = await client.post<
    ReverseSentenceRequest,
    ReverseSentenceResponse
  >("/word-reversal", { input });

  return data;
}
