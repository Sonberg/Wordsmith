import { SentenceReverser } from "components/SentenceReverser";
import { Navigation } from "components/Navigation";

export default function Page() {
  return (
    <div className="bg-gray-100 min-h-screen">
      <Navigation />
      <div className="container mx-auto px-4 min-h-screen mt-48">
        <h3 className="text-xl mb-4">Try it, today!</h3>
        <SentenceReverser />
      </div>
    </div>
  );
}
