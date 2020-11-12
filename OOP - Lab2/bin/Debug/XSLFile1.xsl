<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
    <xsl:output method="html"></xsl:output>

    <xsl:template match="/">
        <html>
            <body>
                <table>
                    <TR>
                        <th>Country</th>
                        <th>Type</th>
                        <th>Class</th>
                        <th>Year</th>
                        <th>Nuclear</th>
                        <th>Length</th>
                    </TR>
                    <xsl:for-each select ="SubmarineDataBase/sub">
                        <tr>
                            <td>
                                <xsl:value-of select ="@Country"/>
                            </td>
                            <td>
                                <xsl:value-of select ="@Type"/>
                            </td>
                            <td>
                                <xsl:value-of select ="@Class"/>
                            </td>
                            <td>
                                <xsl:value-of select ="@Year"/>
                            </td>
                            <td>
                                <xsl:value-of select ="@Nuclear"/>
                            </td>
                            <td>
                                <xsl:value-of select ="@Length"/>
                            </td>
                        </tr>
                    </xsl:for-each>
                </table>
            </body>
        </html>
    </xsl:template>
</xsl:stylesheet>