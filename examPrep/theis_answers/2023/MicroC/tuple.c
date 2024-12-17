void main() {
int t1(|2|);
t1(|0|) = 55;
print t1(|0|); // 55
t1(|1|) = 56;
print t1(|1|); // 56
int i;
i = 0;
while (i < 2) {
print t1(|i|); // 55 56
i = i + 1;
}
}