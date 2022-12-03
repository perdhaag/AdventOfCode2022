import { toUpper, intersection } from "lodash";
import { flow, split, sum, map, chunk } from "lodash/fp";
import { getInput } from "../helpers/retrieveInput";

const valueForCommonChar = (arrs: string[][]) => {
  const [commonChar] = intersection(...arrs);
  if (commonChar === toUpper(commonChar)) {
    return commonChar.charCodeAt(0) - 65 + 1 + 26;
  }
  return commonChar.charCodeAt(0) - 97 + 1;
};

const presentInBoth = (line: string) =>
  flow(split(""), chunk(line.length / 2), valueForCommonChar)(line);

const presentInAllThree = flow(map(split("")), valueForCommonChar);

const part1 = (file: string) =>
  flow(split("\n"), map(presentInBoth), sum)(file);
const part2 = (file: string) =>
  flow(split("\n"), chunk(3), map(presentInAllThree), sum)(file);

const solve = async () => {
  const file = await getInput(3);
  console.log(part1(file), part2(file));
};

solve();
