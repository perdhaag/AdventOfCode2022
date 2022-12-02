import { flow, split, sum, map } from "lodash/fp";
import { getInput } from "../helpers/retrieveInput";
const pointsForLine = (line: string) => {
  // Draw
  if (line === "A X") return 1 + 3;
  if (line === "B Y") return 2 + 3;
  if (line === "C Z") return 3 + 3;
  // Lose
  if (line === "A Z") return 3 + 0;
  if (line === "B X") return 1 + 0;
  if (line === "C Y") return 2 + 0;
  // Win
  if (line === "A Y") return 2 + 6;
  if (line === "B Z") return 3 + 6;
  if (line === "C X") return 1 + 6;
};
const pointsForLine2 = (line: string) => {
  // Draw
  if (line === "A Y") return 1 + 3;
  if (line === "B Y") return 2 + 3;
  if (line === "C Y") return 3 + 3;
  // Lose
  if (line === "A X") return 3 + 0;
  if (line === "B X") return 1 + 0;
  if (line === "C X") return 2 + 0;
  // Win
  if (line === "A Z") return 2 + 6;
  if (line === "B Z") return 3 + 6;
  if (line === "C Z") return 1 + 6;
};
const part1 = (file: string) =>
  flow(split("\n"), map(pointsForLine), sum)(file);

const part2 = (file: string) =>
  flow(split("\n"), map(pointsForLine2), sum)(file);

const solve = async () => {
  const file = await getInput(2);
  console.log(part1(file), part2(file));
};

solve();
