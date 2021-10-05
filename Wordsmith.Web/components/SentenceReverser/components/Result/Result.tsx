import { useMemo } from "react";
import { motion } from "framer-motion";

type Props = {
  value: string;
};

export function Result({ value }: Props) {
  const animate = useMemo(
    () => ({
      y: value ? 0 : 500,
      opacity: value ? 1 : 0,
    }),
    [value]
  );

  return (
    <div className={value ? "h-20" : "h-auto"}>
      <motion.div
        className="mt-8 bg-white shadow-md font-mono rounded-lg overflow-hidden md:max-w-3xl mx-auto"
        animate={animate}
      >
        <div className="bg-gray-300 p-2">
          <div className="flex">
            <div className="h-4 w-4 rounded-full bg-red-600 mr-2"></div>
            <div className="h-4 w-4 rounded-full bg-yellow-400 mr-2"></div>
            <div className="h-4 w-4 rounded-full bg-green-600 mr-2"></div>
            <div></div>
            <div></div>
          </div>
        </div>
        <div className="p-4">{value}</div>
      </motion.div>
    </div>
  );
}
