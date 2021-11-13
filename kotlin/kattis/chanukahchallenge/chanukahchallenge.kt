fun main() {
    val n = readLine()!!.toInt()
    for (i in 1..n) {
        val (_, m) = readLine()!!.toString().split(" ").map { it.toInt() }
        val res = incsum(m) + m
        println("$i $res")
    }
}

fun incsum(n: Int): Int {
    if (n == 1)
        return 1
    return n + incsum(n - 1)
}