import http from "k6/http";
import { check, sleep } from "k6";
import { SharedArray } from "k6/data";

// CONFIGURATION
export const options = {
  stages: [
    { duration: "30s", target: 1000 },
    { duration: "1m", target: 5000 },
    { duration: "30s", target: 10000 },
    { duration: "2m", target: 10000 },
    { duration: "30s", target: 0 },
  ],
  insecureSkipTLSVerify: true,
};

// DATA PREPARATION
const searchTerms = [
  "app",
  "ban",
  "cat",
  "dog",
  "ele",
  "fin",
  "gho",
  "hou",
  "ice",
  "jum",
  "kni",
  "lem",
  "mon",
  "nig",
  "ora",
  "pea",
  "que",
  "rat",
  "sna",
  "tig",
  "umb",
  "van",
  "wat",
  "xyl",
  "yel",
  "zeb",
  "str",
  "th",
  "wh",
  "kn",
];

function getRandomTerm() {
  return searchTerms[Math.floor(Math.random() * searchTerms.length)];
}

// THE VIRTUAL USER
export default function () {
  const term = getRandomTerm();
  const lang = "en"; // Or randomize this if your DB has multiple langs

  const url = `http://localhost:7058/api/dictionary/search/${lang}/${term}`;

  const res = http.get(url);

  check(res, {
    "is status 200": (r) => r.status === 200,
    "latency < 200ms": (r) => r.timings.duration < 200,
  });

  sleep(Math.random() * 1 + 0.5);
}
