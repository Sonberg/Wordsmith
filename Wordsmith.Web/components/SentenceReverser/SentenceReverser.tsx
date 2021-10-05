import { ChangeEvent, useCallback, useEffect, useRef, useState } from "react";

import { reverseSentence } from "services/api";
import { useDebounce } from "hooks/useDebounce";

import { Result } from "./components/Result";

export function SentenceReverser() {
  const [cache, setCache] = useState<Record<string, string>>({});
  const [value, setValue] = useState("");
  const [isLoading, setLoading] = useState(false);
  const [result, setResult] = useState("");

  const ref = useRef<HTMLInputElement | null>(null);
  const debouncedValue = useDebounce(value, 300);

  const handleChange = useCallback(
    (event: ChangeEvent<HTMLInputElement>) => setValue(event.target.value),
    []
  );

  const handleSearch = useCallback(
    async (value: string) => {
      if (cache[value]) {
        return setResult(cache[value]);
      }

      setLoading(true);

      const { reversed } = await reverseSentence(value);

      setResult(reversed);
      setLoading(false);
      setCache((state) => ({
        ...state,
        [value]: reversed,
      }));

      ref.current?.focus();
    },
    [cache]
  );

  useEffect(() => {
    handleSearch(debouncedValue);

    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [debouncedValue]);

  return (
    <>
      <div className="flex">
        <input
          ref={ref}
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
