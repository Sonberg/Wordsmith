import axios, { AxiosResponse } from "axios";

const client = axios.create({
  baseURL: "https://localhost:7272",
});

type ReverseSentenceRequest = {
  value: string;
};

type ReverseSentenceResponse = AxiosResponse<{
  input: string;
  reversed: string;
}>;

export async function reverseSentence(value: string) {
  const { data } = await client.post<
    ReverseSentenceRequest,
    ReverseSentenceResponse
  >("/word-reversal", { value });

  return data;
}
