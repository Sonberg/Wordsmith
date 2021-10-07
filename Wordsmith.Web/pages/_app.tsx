import Head from "next/head";
import "tailwindcss/tailwind.css";
import "style/global.css";

import type { AppProps } from "next/app";

function MyApp({ Component, pageProps }: AppProps) {
  return (
    <>
      <Head>
        <title>Wordsmith inc</title>
      </Head>
      <Component {...pageProps} />
    </>
  );
}
export default MyApp;
