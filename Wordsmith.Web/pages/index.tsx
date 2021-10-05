import { SentenceReverser } from "components/SentenceReverser";
import { Navigation } from "components/Navigation";
import { Partners } from "components/Partners";

export default function Page() {
  return (
    <div className="min-h-screen bg-gray-100">
      <Navigation />
      <div className="container mx-auto px-4 min-h-screen mt-16 md:mt-28">
        <div className="bg-hero-image bg-no-repeat bg-contain h-64 bg-center w-full mb-8"></div>
        <div className="md:w-4/5 md:mx-auto mb-8">
          <div className="uppercase text-sm text-center text-gray-500 mb-4 md:mb-8">
            Try our blazing fast realtime algorithm
          </div>
          <div className="text-3xl md:text-6xl mb-8 md:mb-16 font-bold text-center text-gray-800">
            We are bringing <span className="underline">you</span> tomorrows
            string reversal algorithms <span className="underline">today</span>
          </div>
          <SentenceReverser />
        </div>
        <div className="border-t border-gray mt-16">
          <div className="text-2xl text-center my-8 md:my-16 text-gray-600">
            Trusted by our partners
          </div>
          <Partners />
        </div>
      </div>
    </div>
  );
}
