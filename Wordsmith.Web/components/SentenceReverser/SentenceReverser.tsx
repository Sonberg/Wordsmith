import { ChangeEvent, useCallback, useState } from "react";

export function SentenceReverser() {
  const [value, setValue] = useState("");
  const [isLoading, setLoading] = useState(false);
  const [result, setResult] = useState("");

  const handleChange = useCallback(
    (event: ChangeEvent<HTMLInputElement>) => setValue(event.target.value),
    []
  );

  const handleSubmit = useCallback(() => {
    
  }, []);

  return (
    <div className="flex">
      <input
        value={value}
        onChange={handleChange}
        className="input border border-gray-400 appearance-none rounded w-full px-3 py-3 px-2 focus focus:border-indigo-600 focus:outline-none active:outline-none active:border-indigo-600"
      />
      <button className="bg-indigo-600 hover:bg-blue-dark text-white font-bold py-3 px-6 rounded ml-4">
        Submit
      </button>
    </div>
  );
}
