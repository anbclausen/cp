fun main() {
    val inp = readLine()!!.toString()

    fun solve(s: String, acc: Int): Int {
        val start = s.take(3)
        var res = 0

        if (start[0] != 'P')
            res++
        if (start[1] != 'E')
            res++
        if (start[2] != 'R')
            res++

        val end = s.drop(3)
        if (end != "")
            return solve(end, acc + res)

        return acc + res
    }

    println(solve(inp, 0))
}