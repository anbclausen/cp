fun main() {
    val n = readLine()!!.toInt()
    for (i in 0 until n) {
        val (a, b, c) = readLine()!!.toString().split(" ").map { it.toInt() }
        if (a + b == c || a - b == c || b - a == c || a * b == c)
            println("Possible")
        else if ((a / b.toFloat()) % 1 == 0f && a / b == c)
            println("Possible")
        else if ((b / a.toFloat()) % 1 == 0f && b / a == c)
            println("Possible")
        else
            println("Impossible")
    }
}