import { ChangeEvent, useCallback, useState } from "react";

import { reverseSentence } from "services/api";
import { Result } from "./components/Result";

export function SentenceReverser() {
  const [value, setValue] = useState("");
  const [isLoading, setLoading] = useState(false);
  const [result, setResult] = useState("");

  const handleChange = useCallback(
    (event: ChangeEvent<HTMLInputElement>) => setValue(event.target.value),
    []
  );

  const handleSubmit = useCallback(async () => {
    setLoading(true);

    const { reversed } = await reverseSentence(value);

    setResult(reversed);
    setLoading(false);
  }, [value]);

  return (
    <>
      <div className="flex">
        <input
          value={value}
          disabled={isLoading}
          onChange={handleChange}
          className="input border border-gray-400 appearance-none rounded w-full px-3 py-3 px-2 focus focus:border-indigo-600 focus:outline-none active:outline-none active:border-indigo-600"
        />
        <button
          onClick={handleSubmit}
          disabled={isLoading}
          className="bg-indigo-600 hover:bg-blue-dark text-white font-bold py-3 px-6 rounded ml-4"
        >
          Submit
        </button>
      </div>
      <Result value={result} />
    </>
  );
}
