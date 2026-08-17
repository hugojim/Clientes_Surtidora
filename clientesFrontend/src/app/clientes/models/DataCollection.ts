export interface DataCollection<T> {
  items: T[];
  total: number;
  page: number;
  pageSize: number;
  pages: number;
  hasItems: boolean;
}