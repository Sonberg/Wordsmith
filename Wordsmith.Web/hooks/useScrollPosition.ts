import { useRef, RefObject, useEffect, useCallback } from "react";

const isBrowser = typeof window !== `undefined`;

type GetScrollPositionProps = {
  useWindow: boolean;
  element?: RefObject<HTMLElement>;
};

function getScrollPosition({ element, useWindow }: GetScrollPositionProps) {
  if (!isBrowser) return { x: 0, y: 0 };

  const target = element ? element.current : document.body;
  const position = target?.getBoundingClientRect();

  if (!position) return { x: 0, y: 0 };

  return useWindow
    ? { x: window.scrollX, y: window.scrollY }
    : { x: position.left, y: position.top };
}

type Position = {
  x: number;
  y: number;
};

type EffectProps = {
  prevPos: Position;
  currPos: Position;
};

export function useScrollPosition(
  effect: (_: EffectProps) => void,
  element?: RefObject<HTMLElement>,
  useWindow: boolean = true,
  wait?: number
) {
  const position = useRef(getScrollPosition({ useWindow }));
  const throttleTimeout = useRef<ReturnType<typeof setTimeout> | null>(null);

  const callBack = useCallback(() => {
    const currPos = getScrollPosition({ element, useWindow });
    effect({ prevPos: position.current, currPos });
    position.current = currPos;
    throttleTimeout.current = null;
  }, [effect, element, useWindow]);

  useEffect(() => {
    const handleScroll = () => {
      if (wait) {
        if (throttleTimeout.current === null) {
          throttleTimeout.current = setTimeout(callBack, wait);
        }
      } else {
        callBack();
      }
    };

    window.addEventListener("scroll", handleScroll);

    return () => window.removeEventListener("scroll", handleScroll);
  }, [callBack, wait]);
}
