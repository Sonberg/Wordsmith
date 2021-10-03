type Props = {
  value: string;
};

export function Result({ value }: Props) {
  if (!value) {
    return null;
  }

  return <div className="bg-gray-300 p-4 mt-4 border-t-4 border-gray-800">{value}</div>;
}
