import { useScrollPosition } from "hooks/useScrollPosition";
import { useState } from "react";

export function Navigation() {
  const [scrolledDown, setScrolledDown] = useState(false);

  useScrollPosition(({ currPos }) => setScrolledDown(currPos.y > 88));

  return (
    <div
      className={`transition-all sticky top-0 ${
        scrolledDown ? "bg-white" : "bg-gray-100"
      }`}
    >
      <nav className="container mx-auto py-8 px-4">
        <div className="font-bold uppercase">Wordsmith inc</div>
      </nav>
    </div>
  );
}
