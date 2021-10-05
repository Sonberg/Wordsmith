import { ChangeEvent, useCallback, useState } from "react";

import { reverseSentence } from "services/api";
import { Result } from "./components/Result";

export function SentenceReverser() {
  const [value, setValue] = useState("");
  const [isLoading, setLoading] = useState(false);
  const [result, setResult] = useState("jlk");

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
          placeholder="Write anything, we will reverse it"
          className="input font-semibold border-2 border-gray-400 appearance-none w-full px-3 py-3 px-2 focus focus:border-indigo-600 focus:outline-none active:outline-none active:border-indigo-600 max-w-4xl mx-auto"
        />
      </div>
      <Result value={result} />
    </>
  );
}
